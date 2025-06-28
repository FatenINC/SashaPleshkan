using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public partial class MainForm : Form
    {
        private DataService _dataService;
        
        private readonly Color primaryColor = Color.FromArgb(41, 128, 185);
        private readonly Color secondaryColor = Color.FromArgb(52, 152, 219);
        private readonly Color backgroundColor = Color.FromArgb(236, 240, 241);
        private readonly Color textColor = Color.FromArgb(44, 62, 80);
        private readonly Color successColor = Color.FromArgb(46, 204, 113);
        private readonly Color warningColor = Color.FromArgb(241, 196, 15);
        
        public MainForm()
        {
            _dataService = new DataService();
            InitializeComponent();
            SetupEventHandlers();
            ShowDashboard();
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
            Activated += MainForm_Activated;
            
            dashboardButton.Click += (s, e) => ShowDashboard();
            departmentsButton.Click += (s, e) => OpenDepartmentForm();
            furnitureButton.Click += (s, e) => OpenFurnitureForm();
            assignmentButton.Click += (s, e) => OpenAssignmentForm();
            writeOffButton.Click += (s, e) => OpenWriteOffForm();
            logsButton.Click += (s, e) => OpenLogsForm();
            reportsButton.Click += (s, e) => OpenReportForm();
            importButton.Click += (s, e) => ImportData();
            exportButton.Click += (s, e) => ExportData();
            logoutButton.Click += (s, e) => Application.Exit();
            
            var navButtons = new[] { dashboardButton, furnitureButton, departmentsButton, 
                                   assignmentButton, writeOffButton, reportsButton, logsButton, 
                                   importButton, exportButton, logoutButton };
            
            foreach (var button in navButtons)
            {
                button.MouseEnter += (s, e) => 
                {
                    if (button != dashboardButton || button.BackColor != secondaryColor)
                        button.BackColor = Color.FromArgb(52, 152, 219);
                };
                button.MouseLeave += (s, e) => 
                {
                    if (button != dashboardButton || button.BackColor != secondaryColor)
                        button.BackColor = primaryColor;
                };
            }
            
            dashboardButton.BackColor = secondaryColor;
            
            
            userStatusLabel.Text = $"👤 Пользователь: {Environment.UserName} | 📅 {DateTime.Now:dddd, d MMMM yyyy}";
        }
        
        
        private void ShowDashboard()
        {
            mainContentPanel.Controls.Clear();
            mainContentPanel.Controls.Add(dashboardPanel);
            
            welcomeLabel.Text = $"Добро пожаловать, {Environment.UserName}!";
            dateLabel.Text = DateTime.Now.ToString("dddd, d MMMM yyyy");
            
            var departments = _dataService.GetDepartments();
            var furniture = _dataService.GetFurniture();
            var activeFurniture = furniture.Where(f => !f.IsWrittenOff).ToList();
            var totalValue = activeFurniture.Sum(f => f.Price);
            
            totalFurnitureValueLabel.Text = furniture.Count.ToString();
            activeFurnitureValueLabel.Text = activeFurniture.Count.ToString();
            departmentsValueLabel.Text = departments.Count.ToString();
            totalValueValueLabel.Text = $"{totalValue:N0} ₽";
            
            var recentLogs = _dataService.GetLogs().OrderByDescending(l => l.Timestamp).Take(10).ToList();
            
            var displayLogs = recentLogs.Select(l => new 
            {
                l.Id,
                l.Username,
                Action = TranslateAction(l.Action),
                l.Details,
                l.Timestamp
            }).ToList();
            
            recentActionsDataGridView.DataSource = displayLogs;
            
            if (IsHandleCreated && displayLogs.Any())
            {
                BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (recentActionsDataGridView.Columns.Contains("Id"))
                            recentActionsDataGridView.Columns["Id"].Visible = false;
                            
                        if (recentActionsDataGridView.Columns.Contains("Timestamp"))
                        {
                            recentActionsDataGridView.Columns["Timestamp"].DefaultCellStyle.Format = "g";
                            recentActionsDataGridView.Columns["Timestamp"].Width = 150;
                            recentActionsDataGridView.Columns["Timestamp"].HeaderText = "Время";
                        }
                        
                        if (recentActionsDataGridView.Columns.Contains("Username"))
                            recentActionsDataGridView.Columns["Username"].HeaderText = "Пользователь";
                            
                        if (recentActionsDataGridView.Columns.Contains("Action"))
                            recentActionsDataGridView.Columns["Action"].HeaderText = "Действие";
                            
                        if (recentActionsDataGridView.Columns.Contains("Details"))
                            recentActionsDataGridView.Columns["Details"].HeaderText = "Детали";
                    }
                    catch
                    {
                    }
                }));
            }
        }
        
        
        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (mainContentPanel.Controls.Contains(dashboardPanel))
            {
                ShowDashboard();
            }
        }
        
        private void OpenDepartmentForm()
        {
            var form = new DepartmentForm(_dataService);
            form.ShowDialog();
            ShowDashboard();
        }
        
        private void OpenFurnitureForm()
        {
            var form = new FurnitureForm(_dataService);
            form.ShowDialog();
            ShowDashboard();
        }
        
        private void OpenAssignmentForm()
        {
            var form = new AssignmentForm(_dataService);
            form.ShowDialog();
            ShowDashboard();
        }
        
        private void OpenWriteOffForm()
        {
            var form = new WriteOffForm(_dataService);
            form.ShowDialog();
            ShowDashboard();
        }
        
        private void OpenLogsForm()
        {
            var form = new LogsForm(_dataService);
            form.ShowDialog();
        }
        
        private void OpenReportForm()
        {
            var form = new ReportForm(_dataService);
            form.ShowDialog();
        }
        
        private void ImportData()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "JSON файлы (*.json)|*.json";
                dialog.Title = "Импорт данных";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _dataService.ImportData(dialog.FileName);
                        MessageBox.Show("Данные успешно импортированы!", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowDashboard();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка импорта: {ex.Message}", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void ExportData()
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "JSON файлы (*.json)|*.json";
                dialog.Title = "Экспорт данных";
                dialog.FileName = $"furniture_data_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _dataService.ExportData(dialog.FileName);
                        MessageBox.Show("Данные успешно экспортированы!", "Успех", 
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