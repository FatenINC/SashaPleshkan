using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Models;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public partial class AssignmentForm : Form
    {
        private DataService _dataService;
        
        public AssignmentForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            SetupEventHandlers();
            LoadData();
        }
        
        private void SetupEventHandlers()
        {
            furnitureComboBox.SelectedIndexChanged += FurnitureComboBox_SelectedIndexChanged;
            assignButton.Click += AssignButton_Click;
            unassignButton.Click += UnassignButton_Click;
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
            departmentComboBox.DisplayMember = "Name";
            departmentComboBox.ValueMember = "Id";
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
                            unassignButton.Enabled = true;
                        }
                    }
                    else
                    {
                        currentAssignmentLabel.Text = "Не назначено";
                        currentAssignmentLabel.ForeColor = Color.Gray;
                        unassignButton.Enabled = false;
                    }
                }
            }
        }
        
        private void AssignButton_Click(object sender, EventArgs e)
        {
            if (furnitureComboBox.SelectedItem == null || departmentComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите мебель и отдел!", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var selectedFurniture = furnitureComboBox.SelectedItem as ComboBoxItem;
            var department = departmentComboBox.SelectedItem as Department;
            
            if (selectedFurniture != null && department != null)
            {
                _dataService.AssignFurnitureToDepartment(selectedFurniture.Id, department.Id);
                
                MessageBox.Show($"Мебель успешно назначена отделу {department.Name}!", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                LoadData();
                FurnitureComboBox_SelectedIndexChanged(null, null);
            }
        }
        
        private void UnassignButton_Click(object sender, EventArgs e)
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
                    
                    MessageBox.Show("Назначение успешно отменено!", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    LoadData();
                    FurnitureComboBox_SelectedIndexChanged(null, null);
                }
            }
        }
    }
}