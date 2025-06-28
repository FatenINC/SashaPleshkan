using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public class LogsForm : Form
    {
        private DataService _dataService;
        private DataGridView gridView;
        private DateTimePicker fromDatePicker;
        private DateTimePicker toDatePicker;
        private ComboBox actionFilterComboBox;
        private Button filterButton;
        private Button clearFilterButton;
        private Button exportButton;
        
        public LogsForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponents();
        }
        
        private void InitializeComponents()
        {
            Text = "Action Logs";
            Size = new Size(900, 600);
            StartPosition = FormStartPosition.CenterParent;
            Load += LogsForm_Load;
            
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(10)
            };
            
            var filterPanel = new GroupBox
            {
                Text = "Filter Options",
                Height = 100,
                Dock = DockStyle.Top
            };
            
            var filterLayout = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Padding = new Padding(10)
            };
            
            filterLayout.Controls.Add(new Label { Text = "From:", AutoSize = true, Anchor = AnchorStyles.Left });
            fromDatePicker = new DateTimePicker { Width = 120 };
            filterLayout.Controls.Add(fromDatePicker);
            
            filterLayout.Controls.Add(new Label { Text = "To:", AutoSize = true, Anchor = AnchorStyles.Left });
            toDatePicker = new DateTimePicker { Width = 120 };
            filterLayout.Controls.Add(toDatePicker);
            
            filterLayout.Controls.Add(new Label { Text = "Action:", AutoSize = true, Anchor = AnchorStyles.Left });
            actionFilterComboBox = new ComboBox 
            { 
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            filterLayout.Controls.Add(actionFilterComboBox);
            
            filterButton = new Button { Text = "Apply Filter", Width = 100 };
            filterButton.Click += FilterButton_Click;
            filterLayout.Controls.Add(filterButton);
            
            clearFilterButton = new Button { Text = "Clear Filter", Width = 100 };
            clearFilterButton.Click += ClearFilterButton_Click;
            filterLayout.Controls.Add(clearFilterButton);
            
            exportButton = new Button { Text = "Export Logs", Width = 100 };
            exportButton.Click += ExportButton_Click;
            filterLayout.Controls.Add(exportButton);
            
            filterPanel.Controls.Add(filterLayout);
            
            gridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };
            
            mainPanel.Controls.Add(filterPanel, 0, 0);
            mainPanel.Controls.Add(gridView, 0, 1);
            
            Controls.Add(mainPanel);
        }
        
        private void LogsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void LoadData()
        {
            var logs = _dataService.GetLogs().OrderByDescending(l => l.Timestamp).ToList();
            gridView.DataSource = logs;
            
            // Use BeginInvoke only if handle is created
            if (logs.Any() && IsHandleCreated)
            {
                BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (gridView.Columns.Contains("Id"))
                            gridView.Columns["Id"].Width = 50;
                        if (gridView.Columns.Contains("Timestamp"))
                        {
                            gridView.Columns["Timestamp"].DefaultCellStyle.Format = "g";
                            gridView.Columns["Timestamp"].Width = 150;
                        }
                        if (gridView.Columns.Contains("Username"))
                            gridView.Columns["Username"].Width = 100;
                        if (gridView.Columns.Contains("Action"))
                            gridView.Columns["Action"].Width = 150;
                    }
                    catch
                    {
                        // Ignore column formatting errors
                    }
                }));
            }
            
            var actions = logs.Select(l => l.Action).Distinct().OrderBy(a => a).ToList();
            actions.Insert(0, "All Actions");
            actionFilterComboBox.DataSource = actions;
            actionFilterComboBox.SelectedIndex = 0;
            
            if (logs.Any())
            {
                fromDatePicker.Value = logs.Min(l => l.Timestamp).Date;
                toDatePicker.Value = DateTime.Now.Date.AddDays(1);
            }
        }
        
        private void FilterButton_Click(object sender, EventArgs e)
        {
            var logs = _dataService.GetLogs()
                .Where(l => l.Timestamp >= fromDatePicker.Value.Date && 
                           l.Timestamp <= toDatePicker.Value.Date.AddDays(1))
                .OrderByDescending(l => l.Timestamp)
                .ToList();
                
            if (actionFilterComboBox.Text != "All Actions")
            {
                logs = logs.Where(l => l.Action == actionFilterComboBox.Text).ToList();
            }
            
            gridView.DataSource = logs;
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
                dialog.Title = "Export Logs";
                dialog.FileName = $"action_logs_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var logs = gridView.DataSource as System.Collections.Generic.List<FurnitureAccounting.Models.ActionLog>;
                        var lines = new System.Collections.Generic.List<string>();
                        
                        lines.Add("ID,Username,Action,Details,Timestamp");
                        
                        foreach (var log in logs)
                        {
                            lines.Add($"{log.Id},\"{log.Username}\",\"{log.Action}\",\"{log.Details}\",\"{log.Timestamp:yyyy-MM-dd HH:mm:ss}\"");
                        }
                        
                        System.IO.File.WriteAllLines(dialog.FileName, lines);
                        
                        MessageBox.Show("Logs exported successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Export failed: {ex.Message}", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}