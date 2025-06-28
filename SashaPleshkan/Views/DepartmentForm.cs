using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Models;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public class DepartmentForm : Form
    {
        private DataService _dataService;
        private DataGridView gridView;
        private TextBox nameTextBox;
        private TextBox descriptionTextBox;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Department _selectedDepartment;
        
        public DepartmentForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponents();
        }
        
        private void InitializeComponents()
        {
            Text = "Manage Departments";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.FromArgb(245, 247, 250);
            Load += DepartmentForm_Load;
            
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 2,
                Padding = new Padding(10)
            };
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 240));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            
            var inputPanel = new Panel
            {
                Height = 220,
                Dock = DockStyle.Top,
                BackColor = Color.White,
                Padding = new Padding(20)
            };
            
            var titleLabel = new Label
            {
                Text = "Department Details",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true,
                Location = new Point(20, 10)
            };
            inputPanel.Controls.Add(titleLabel);
            
            var inputLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 3,
                Padding = new Padding(20, 40, 20, 10),
                BackColor = Color.White
            };
            
            inputLayout.Controls.Add(new Label { Text = "Name:", Anchor = AnchorStyles.Right, Font = new Font("Segoe UI", 10) }, 0, 0);
            nameTextBox = new TextBox { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle };
            inputLayout.Controls.Add(nameTextBox, 1, 0);
            
            inputLayout.Controls.Add(new Label { Text = "Description:", Anchor = AnchorStyles.Right, Font = new Font("Segoe UI", 10) }, 0, 1);
            descriptionTextBox = new TextBox { Dock = DockStyle.Fill, Multiline = true, Height = 50, Font = new Font("Segoe UI", 10), BorderStyle = BorderStyle.FixedSingle, ScrollBars = ScrollBars.Vertical };
            inputLayout.Controls.Add(descriptionTextBox, 1, 1);
            
            var buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Fill
            };
            
            addButton = new Button 
            { 
                Text = "➕ Add", 
                Width = 100, 
                Height = 35,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            addButton.FlatAppearance.BorderSize = 0;
            addButton.Click += AddButton_Click;
            
            updateButton = new Button 
            { 
                Text = "✏️ Update", 
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Enabled = false,
                Cursor = Cursors.Hand
            };
            updateButton.FlatAppearance.BorderSize = 0;
            updateButton.Click += UpdateButton_Click;
            
            deleteButton = new Button 
            { 
                Text = "🗑️ Delete", 
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(231, 76, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Enabled = false,
                Cursor = Cursors.Hand
            };
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.Click += DeleteButton_Click;
            
            buttonPanel.Controls.Add(addButton);
            buttonPanel.Controls.Add(updateButton);
            buttonPanel.Controls.Add(deleteButton);
            
            inputLayout.Controls.Add(buttonPanel, 1, 2);
            inputPanel.Controls.Add(inputLayout);
            
            gridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                EnableHeadersVisualStyles = false,
                Font = new Font("Segoe UI", 10)
            };
            
            // Style the grid
            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            gridView.ColumnHeadersHeight = 40;
            gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            gridView.DefaultCellStyle.SelectionForeColor = Color.White;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            gridView.SelectionChanged += GridView_SelectionChanged;
            
            mainPanel.Controls.Add(inputPanel, 0, 0);
            mainPanel.Controls.Add(gridView, 0, 1);
            
            Controls.Add(mainPanel);
        }
        
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void LoadData()
        {
            var departments = _dataService.GetDepartments();
            gridView.DataSource = departments;
            
            // Use BeginInvoke only if handle is created
            if (departments.Any() && IsHandleCreated)
            {
                BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (gridView.Columns.Contains("Id"))
                            gridView.Columns["Id"].Width = 50;
                    }
                    catch
                    {
                        // Ignore column formatting errors
                    }
                }));
            }
        }
        
        private void GridView_SelectionChanged(object sender, EventArgs e)
        {
            if (gridView.SelectedRows.Count > 0)
            {
                _selectedDepartment = gridView.SelectedRows[0].DataBoundItem as Department;
                if (_selectedDepartment != null)
                {
                    nameTextBox.Text = _selectedDepartment.Name;
                    descriptionTextBox.Text = _selectedDepartment.Description;
                    updateButton.Enabled = true;
                    deleteButton.Enabled = true;
                }
            }
            else
            {
                ClearForm();
            }
        }
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var department = new Department
                {
                    Name = nameTextBox.Text.Trim(),
                    Description = descriptionTextBox.Text.Trim()
                };
                
                _dataService.AddDepartment(department);
                LoadData();
                ClearForm();
                MessageBox.Show("Department added successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_selectedDepartment != null && ValidateInput())
            {
                _selectedDepartment.Name = nameTextBox.Text.Trim();
                _selectedDepartment.Description = descriptionTextBox.Text.Trim();
                
                _dataService.UpdateDepartment(_selectedDepartment);
                LoadData();
                ClearForm();
                MessageBox.Show("Department updated successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_selectedDepartment != null)
            {
                var furniture = _dataService.GetFurnitureByDepartment(_selectedDepartment.Id);
                if (furniture.Any())
                {
                    MessageBox.Show("Cannot delete department with assigned furniture!", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                var result = MessageBox.Show($"Are you sure you want to delete '{_selectedDepartment.Name}'?", 
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    _dataService.DeleteDepartment(_selectedDepartment.Id);
                    LoadData();
                    ClearForm();
                    MessageBox.Show("Department deleted successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Please enter department name!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();
                return false;
            }
            
            return true;
        }
        
        private void ClearForm()
        {
            nameTextBox.Clear();
            descriptionTextBox.Clear();
            _selectedDepartment = null;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }
    }
}