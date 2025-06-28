using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Models;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public class AssignmentForm : Form
    {
        private DataService _dataService;
        private ComboBox furnitureComboBox;
        private ComboBox departmentComboBox;
        private Label currentAssignmentLabel;
        private Button assignButton;
        private Button clearAssignmentButton;
        
        public AssignmentForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponents();
            LoadData();
        }
        
        private void InitializeComponents()
        {
            Text = "Assign Furniture to Department";
            Size = new Size(500, 300);
            StartPosition = FormStartPosition.CenterParent;
            
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 5,
                Padding = new Padding(20)
            };
            
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            
            mainPanel.Controls.Add(new Label { Text = "Furniture:", Anchor = AnchorStyles.Right }, 0, 0);
            furnitureComboBox = new ComboBox 
            { 
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "DisplayText"
            };
            furnitureComboBox.SelectedIndexChanged += FurnitureComboBox_SelectedIndexChanged;
            mainPanel.Controls.Add(furnitureComboBox, 1, 0);
            
            mainPanel.Controls.Add(new Label { Text = "Current Assignment:", Anchor = AnchorStyles.Right }, 0, 1);
            currentAssignmentLabel = new Label 
            { 
                Text = "Not assigned",
                ForeColor = Color.Gray,
                Anchor = AnchorStyles.Left
            };
            mainPanel.Controls.Add(currentAssignmentLabel, 1, 1);
            
            mainPanel.Controls.Add(new Label { Text = "Assign to Department:", Anchor = AnchorStyles.Right }, 0, 2);
            departmentComboBox = new ComboBox 
            { 
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "Name"
            };
            mainPanel.Controls.Add(departmentComboBox, 1, 2);
            
            var buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Fill
            };
            
            assignButton = new Button { Text = "Assign", Width = 100 };
            assignButton.Click += AssignButton_Click;
            clearAssignmentButton = new Button { Text = "Clear Assignment", Width = 120 };
            clearAssignmentButton.Click += ClearAssignmentButton_Click;
            
            buttonPanel.Controls.Add(assignButton);
            buttonPanel.Controls.Add(clearAssignmentButton);
            
            mainPanel.Controls.Add(buttonPanel, 1, 3);
            
            Controls.Add(mainPanel);
        }
        
        private void LoadData()
        {
            var furniture = _dataService.GetFurniture()
                .Where(f => !f.IsWrittenOff)
                .Select(f => new ComboBoxItem
                {
                    Id = f.Id,
                    DisplayText = $"{f.Name} ({f.InventoryNumber})",
                    DepartmentId = f.DepartmentId
                })
                .ToList();
                
            furnitureComboBox.DataSource = furniture;
            furnitureComboBox.DisplayMember = "DisplayText";
            furnitureComboBox.ValueMember = "Id";
            
            var departments = _dataService.GetDepartments();
            departmentComboBox.DataSource = departments;
        }
        
        private void FurnitureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (furnitureComboBox.SelectedItem != null)
            {
                var selected = furnitureComboBox.SelectedItem as ComboBoxItem;
                if (selected != null)
                {
                    var furniture = _dataService.GetFurnitureItem(selected.Id);
                    
                    if (furniture != null && furniture.DepartmentId.HasValue)
                    {
                        var department = _dataService.GetDepartment(furniture.DepartmentId.Value);
                        if (department != null)
                        {
                            currentAssignmentLabel.Text = department.Name;
                            currentAssignmentLabel.ForeColor = Color.Black;
                            clearAssignmentButton.Enabled = true;
                        }
                    }
                    else
                    {
                        currentAssignmentLabel.Text = "Not assigned";
                        currentAssignmentLabel.ForeColor = Color.Gray;
                        clearAssignmentButton.Enabled = false;
                    }
                }
            }
        }
        
        private void AssignButton_Click(object sender, EventArgs e)
        {
            if (furnitureComboBox.SelectedItem == null || departmentComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select both furniture and department!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var selectedFurniture = furnitureComboBox.SelectedItem as ComboBoxItem;
            var department = departmentComboBox.SelectedItem as Department;
            
            if (selectedFurniture != null && department != null)
            {
                _dataService.AssignFurnitureToDepartment(selectedFurniture.Id, department.Id);
                
                MessageBox.Show($"Furniture assigned to {department.Name} successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                LoadData();
                FurnitureComboBox_SelectedIndexChanged(null, null);
            }
        }
        
        private void ClearAssignmentButton_Click(object sender, EventArgs e)
        {
            if (furnitureComboBox.SelectedItem == null)
                return;
                
            var selectedFurniture = furnitureComboBox.SelectedItem as ComboBoxItem;
            if (selectedFurniture != null)
            {
                var furniture = _dataService.GetFurnitureItem(selectedFurniture.Id);
                
                if (furniture != null)
                {
                    furniture.DepartmentId = null;
                    _dataService.UpdateFurniture(furniture);
                    
                    MessageBox.Show("Assignment cleared successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    LoadData();
                    FurnitureComboBox_SelectedIndexChanged(null, null);
                }
            }
        }
    }
}