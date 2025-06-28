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
            Text = "Система учета мебели";
            Size = new Size(1800, 950);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = backgroundColor;
            Activated += MainForm_Activated;
            
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
                Text = "СИСТЕМА\nУЧЕТА МЕБЕЛИ",
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
            
            AddNavButton(navPanel, "📊 Главная", ShowDashboard, "Общая статистика и последние действия");
            AddNavButton(navPanel, "🏢 Отделы", () => OpenDepartmentForm(), "Управление отделами организации");
            AddNavButton(navPanel, "🪑 Мебель", () => OpenFurnitureForm(), "Добавление и редактирование мебели");
            AddNavButton(navPanel, "📎 Назначить", () => OpenAssignmentForm(), "Закрепить мебель за отделом");
            AddNavButton(navPanel, "❌ Списать", () => OpenWriteOffForm(), "Списание негодной мебели");
            AddNavButton(navPanel, "📋 Журнал", () => OpenLogsForm(), "Просмотр истории действий");
            AddNavButton(navPanel, "📈 Отчеты", () => OpenReportForm(), "Формирование отчетов");
            AddNavSeparator(navPanel);
            AddNavButton(navPanel, "📥 Импорт", ImportData, "Загрузить данные из файла");
            AddNavButton(navPanel, "📤 Экспорт", ExportData, "Сохранить данные в файл");
            
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
            statusLabel = new ToolStripStatusLabel($"👤 Пользователь: {Environment.UserName} | 📅 {DateTime.Now:dddd, d MMMM yyyy}");
            statusStrip.Items.Add(statusLabel);
            
            Controls.Add(mainContentPanel);
            Controls.Add(sidebarPanel);
            Controls.Add(statusStrip);
        }
        
        private void AddNavButton(FlowLayoutPanel parent, string text, Action onClick, string tooltip = null)
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
            
            if (!string.IsNullOrEmpty(tooltip))
            {
                var toolTip = new ToolTip();
                toolTip.SetToolTip(button, tooltip);
            }
            
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
                Text = "Обзор системы",
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
            
            CreateStatCard(cardsPanel, "Всего отделов", departments.Count.ToString(), "🏢", primaryColor);
            CreateStatCard(cardsPanel, "Активная мебель", activeFurniture.Count.ToString(), "🪑", successColor);
            CreateStatCard(cardsPanel, "Списано", writtenOffFurniture.Count.ToString(), "❌", warningColor);
            CreateStatCard(cardsPanel, "Общая стоимость", $"${totalValue:N2}", "💰", secondaryColor);
            
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
                Text = "Последние действия",
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
                Width = 380,
                Height = 130,
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
                Location = new Point(20, 30),
                AutoSize = true
            };
            
            var valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(100, 25),
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
        
        private void MainForm_Activated(object sender, EventArgs e)
        {
            // Refresh dashboard when main form is activated
            if (mainContentPanel.Controls.Contains(dashboardPanel))
            {
                ShowDashboard();
            }
        }
        
        private void OpenDepartmentForm()
        {
            var form = new DepartmentForm(_dataService);
            form.ShowDialog();
            ShowDashboard(); // Refresh dashboard after changes
        }
        
        private void OpenFurnitureForm()
        {
            var form = new FurnitureForm(_dataService);
            form.ShowDialog();
            ShowDashboard(); // Refresh dashboard after changes
        }
        
        private void OpenAssignmentForm()
        {
            var form = new AssignmentForm(_dataService);
            form.ShowDialog();
            ShowDashboard(); // Refresh dashboard after changes
        }
        
        private void OpenWriteOffForm()
        {
            var form = new WriteOffForm(_dataService);
            form.ShowDialog();
            ShowDashboard(); // Refresh dashboard after changes
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
                        ShowDashboard(); // Refresh dashboard after import
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