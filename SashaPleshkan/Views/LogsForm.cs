using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public partial class LogsForm : Form
    {
        private DataService _dataService;
        
        public LogsForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            SetupEventHandlers();
        }
        
        private string TranslateAction(string action)
        {
            var translations = new System.Collections.Generic.Dictionary<string, string>
            {
                { "Add Department", "Добавить отдел" },
                { "Update Department", "Обновить отдел" },
                { "Delete Department", "Удалить отдел" },
                { "Add Furniture", "Добавить мебель" },
                { "Update Furniture", "Обновить мебель" },
                { "Delete Furniture", "Удалить мебель" },
                { "Assign Furniture", "Назначить мебель" },
                { "Write-off Furniture", "Списать мебель" },
                { "Export Data", "Экспорт данных" },
                { "Import Data", "Импорт данных" }
            };
            
            return translations.ContainsKey(action) ? translations[action] : action;
        }
        
        private void SetupEventHandlers()
        {
            Load += LogsForm_Load;
            applyButton.Click += FilterButton_Click;
            clearButton.Click += ClearFilterButton_Click;
            exportButton.Click += ExportButton_Click;
        }
        
        private void LogsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void LoadData()
        {
            var logs = _dataService.GetLogs().OrderByDescending(l => l.Timestamp).ToList();
            
            var displayLogs = logs.Select(l => new 
            {
                l.Id,
                l.Username,
                Action = TranslateAction(l.Action),
                l.Details,
                l.Timestamp
            }).ToList();
            
            logsDataGridView.DataSource = displayLogs;
            
            if (logs.Any() && IsHandleCreated)
            {
                BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (logsDataGridView.Columns.Contains("Id"))
                        {
                            logsDataGridView.Columns["Id"].Width = 50;
                            logsDataGridView.Columns["Id"].HeaderText = "ID";
                        }
                        if (logsDataGridView.Columns.Contains("Timestamp"))
                        {
                            logsDataGridView.Columns["Timestamp"].DefaultCellStyle.Format = "g";
                            logsDataGridView.Columns["Timestamp"].Width = 150;
                            logsDataGridView.Columns["Timestamp"].HeaderText = "Время";
                        }
                        if (logsDataGridView.Columns.Contains("Username"))
                        {
                            logsDataGridView.Columns["Username"].Width = 100;
                            logsDataGridView.Columns["Username"].HeaderText = "Пользователь";
                        }
                        if (logsDataGridView.Columns.Contains("Action"))
                        {
                            logsDataGridView.Columns["Action"].Width = 150;
                            logsDataGridView.Columns["Action"].HeaderText = "Действие";
                        }
                        if (logsDataGridView.Columns.Contains("Details"))
                        {
                            logsDataGridView.Columns["Details"].HeaderText = "Детали";
                        }
                    }
                    catch
                    {
                    }
                }));
            }
            
            var actions = logs.Select(l => TranslateAction(l.Action)).Distinct().OrderBy(a => a).ToList();
            actions.Insert(0, "Все действия");
            actionComboBox.DataSource = actions;
            actionComboBox.SelectedIndex = 0;
            
            if (logs.Any())
            {
                fromDateTimePicker.Value = logs.Min(l => l.Timestamp).Date;
                toDateTimePicker.Value = DateTime.Now.Date.AddDays(1);
            }
        }
        
        private void FilterButton_Click(object sender, EventArgs e)
        {
            var logs = _dataService.GetLogs()
                .Where(l => l.Timestamp >= fromDateTimePicker.Value.Date && 
                           l.Timestamp <= toDateTimePicker.Value.Date.AddDays(1))
                .OrderByDescending(l => l.Timestamp)
                .ToList();
                
            if (actionComboBox.Text != "Все действия")
            {
                logs = logs.Where(l => TranslateAction(l.Action) == actionComboBox.Text).ToList();
            }
            
            var displayLogs = logs.Select(l => new 
            {
                l.Id,
                l.Username,
                Action = TranslateAction(l.Action),
                l.Details,
                l.Timestamp
            }).ToList();
            
            logsDataGridView.DataSource = displayLogs;
        }
        
        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void ExportButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt";
                dialog.Title = "Экспорт журнала";
                dialog.FileName = $"action_logs_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var logs = logsDataGridView.DataSource as System.Collections.IList;
                        var lines = new System.Collections.Generic.List<string>();
                        
                        lines.Add("ID,Пользователь,Действие,Детали,Время");
                        
                        foreach (var log in logs)
                        {
                            dynamic logItem = log;
                            lines.Add($"{logItem.Id},\"{logItem.Username}\",\"{logItem.Action}\",\"{logItem.Details}\",\"{logItem.Timestamp:yyyy-MM-dd HH:mm:ss}\"");
                        }
                        
                        System.IO.File.WriteAllLines(dialog.FileName, lines);
                        
                        MessageBox.Show("Журнал успешно экспортирован!", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}