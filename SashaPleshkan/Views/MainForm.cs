using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public class MainForm : Form
    {
        private DataService _dataService;
        private Panel sidebarPanel;
        private Panel mainContentPanel;
        private Panel dashboardPanel;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        
        private readonly Color primaryColor = Color.FromArgb(41, 128, 185);
        private readonly Color secondaryColor = Color.FromArgb(52, 152, 219);
        private readonly Color backgroundColor = Color.FromArgb(236, 240, 241);
        private readonly Color textColor = Color.FromArgb(44, 62, 80);
        private readonly Color successColor = Color.FromArgb(46, 204, 113);
        private readonly Color warningColor = Color.FromArgb(241, 196, 15);
        
        public MainForm()
        {
            _dataService = new DataService();
            InitializeComponents();
            ShowDashboard();
        }
        
        private void InitializeComponents()
        {
            Text = "Furniture Accounting System";
            Size = new Size(1200, 800);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = backgroundColor;
            
            // Create sidebar
            sidebarPanel = new Panel
            {
                Width = 250,
                Dock = DockStyle.Left,
                BackColor = primaryColor
            };
            
            // Logo/Title Panel  
            var titlePanel = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = primaryColor,
                Padding = new Padding(5)
            };
            
            var titleLabel = new Label
            {
                Text = "FURNITURE\nACCOUNTING",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            titlePanel.Controls.Add(titleLabel);
            
            // Navigation buttons
            var navPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 10, 0, 0),
                AutoScroll = true
            };
            
            AddNavButton(navPanel, "📊 Dashboard", ShowDashboard);
            AddNavButton(navPanel, "🏢 Departments", () => OpenDepartmentForm());
            AddNavButton(navPanel, "🪑 Furniture", () => OpenFurnitureForm());
            AddNavButton(navPanel, "📎 Assign Items", () => OpenAssignmentForm());
            AddNavButton(navPanel, "❌ Write-off", () => OpenWriteOffForm());
            AddNavButton(navPanel, "📋 View Logs", () => OpenLogsForm());
            AddNavButton(navPanel, "📈 Reports", () => OpenReportForm());
            AddNavSeparator(navPanel);
            AddNavButton(navPanel, "📥 Import Data", ImportData);
            AddNavButton(navPanel, "📤 Export Data", ExportData);
            
            // Add controls in correct order
            sidebarPanel.Controls.Add(navPanel);
            sidebarPanel.Controls.Add(titlePanel);
            
            // Main content area
            mainContentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = backgroundColor,
                Padding = new Padding(20)
            };
            
            // Status bar
            statusStrip = new StatusStrip
            {
                BackColor = Color.White
            };
            statusLabel = new ToolStripStatusLabel($"👤 User: {Environment.UserName} | 📅 {DateTime.Now:dddd, MMMM d, yyyy}");
            statusStrip.Items.Add(statusLabel);
            
            Controls.Add(mainContentPanel);
            Controls.Add(sidebarPanel);
            Controls.Add(statusStrip);
        }
        
        private void AddNavButton(FlowLayoutPanel parent, string text, Action onClick)
        {
            var button = new Button
            {
                Text = text,
                Width = 220,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(15, 0, 0, 0),
                Cursor = Cursors.Hand,
                Margin = new Padding(15, 2, 15, 2)
            };
            
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = secondaryColor;
            button.Click += (s, e) => onClick();
            
            parent.Controls.Add(button);
        }
        
        private void AddNavSeparator(FlowLayoutPanel parent)
        {
            parent.Controls.Add(new Panel
            {
                Height = 1,
                Width = 200,
                BackColor = Color.FromArgb(100, 255, 255, 255),
                Margin = new Padding(25, 10, 25, 10)
            });
        }
        
        private void ShowDashboard()
        {
            mainContentPanel.Controls.Clear();
            
            dashboardPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            
            // Title
            var titleLabel = new Label
            {
                Text = "Dashboard Overview",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = textColor,
                AutoSize = true,
                Location = new Point(0, 0)
            };
            dashboardPanel.Controls.Add(titleLabel);
            
            // Statistics cards
            var cardsPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Location = new Point(0, 60),
                AutoSize = true,
                WrapContents = true,
                Width = mainContentPanel.Width - 40
            };
            
            var departments = _dataService.GetDepartments();
            var furniture = _dataService.GetFurniture();
            var activeFurniture = furniture.Where(f => !f.IsWrittenOff).ToList();
            var writtenOffFurniture = furniture.Where(f => f.IsWrittenOff).ToList();
            var totalValue = activeFurniture.Sum(f => f.Price);
            
            CreateStatCard(cardsPanel, "Total Departments", departments.Count.ToString(), "🏢", primaryColor);
            CreateStatCard(cardsPanel, "Active Furniture", activeFurniture.Count.ToString(), "🪑", successColor);
            CreateStatCard(cardsPanel, "Written Off", writtenOffFurniture.Count.ToString(), "❌", warningColor);
            CreateStatCard(cardsPanel, "Total Value", $"${totalValue:N2}", "💰", secondaryColor);
            
            dashboardPanel.Controls.Add(cardsPanel);
            
            // Recent activity
            var activityPanel = new Panel
            {
                Location = new Point(0, 250),
                Width = mainContentPanel.Width - 40,
                Height = 300
            };
            
            var activityTitle = new Label
            {
                Text = "Recent Activity",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(0, 0),
                AutoSize = true
            };
            activityPanel.Controls.Add(activityTitle);
            
            var activityGrid = new DataGridView
            {
                Location = new Point(0, 40),
                Width = activityPanel.Width,
                Height = 250,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false
            };
            
            var recentLogs = _dataService.GetLogs().OrderByDescending(l => l.Timestamp).Take(10).ToList();
            activityGrid.DataSource = recentLogs;
            
            if (activityGrid.Columns["Id"] != null)
            {
                activityGrid.Columns["Id"].Visible = false;
                activityGrid.Columns["Timestamp"].DefaultCellStyle.Format = "g";
                activityGrid.Columns["Timestamp"].Width = 150;
            }
            
            activityPanel.Controls.Add(activityGrid);
            dashboardPanel.Controls.Add(activityPanel);
            
            mainContentPanel.Controls.Add(dashboardPanel);
        }
        
        private void CreateStatCard(FlowLayoutPanel parent, string title, string value, string icon, Color color)
        {
            var card = new Panel
            {
                Width = 250,
                Height = 120,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 20, 20)
            };
            
            // Add shadow effect
            card.Paint += (s, e) =>
            {
                var rect = new Rectangle(2, 2, card.Width - 4, card.Height - 4);
                using (var brush = new SolidBrush(Color.FromArgb(30, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };
            
            var iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 32),
                ForeColor = color,
                Location = new Point(20, 20),
                AutoSize = true
            };
            
            var valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(100, 20),
                AutoSize = true
            };
            
            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.Gray,
                Location = new Point(100, 60),
                AutoSize = true
            };
            
            card.Controls.AddRange(new Control[] { iconLabel, valueLabel, titleLabel });
            parent.Controls.Add(card);
        }
        
        private void OpenDepartmentForm()
        {
            var form = new DepartmentForm(_dataService);
            form.ShowDialog();
        }
        
        private void OpenFurnitureForm()
        {
            var form = new FurnitureForm(_dataService);
            form.ShowDialog();
        }
        
        private void OpenAssignmentForm()
        {
            var form = new AssignmentForm(_dataService);
            form.ShowDialog();
        }
        
        private void OpenWriteOffForm()
        {
            var form = new WriteOffForm(_dataService);
            form.ShowDialog();
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
                dialog.Filter = "JSON files (*.json)|*.json";
                dialog.Title = "Import Data";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _dataService.ImportData(dialog.FileName);
                        MessageBox.Show("Data imported successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Import failed: {ex.Message}", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void ExportData()
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "JSON files (*.json)|*.json";
                dialog.Title = "Export Data";
                dialog.FileName = $"furniture_data_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _dataService.ExportData(dialog.FileName);
                        MessageBox.Show("Data exported successfully!", "Success", 
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