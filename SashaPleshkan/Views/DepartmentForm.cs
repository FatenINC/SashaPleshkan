using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Models;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public partial class DepartmentForm : Form
    {
        private DataService _dataService;
        private Department _selectedDepartment;
        
        public DepartmentForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            SetupEventHandlers();
        }
        
        private void SetupEventHandlers()
        {
            Load += DepartmentForm_Load;
            departmentsDataGridView.SelectionChanged += GridView_SelectionChanged;
            addButton.Click += AddButton_Click;
            updateButton.Click += UpdateButton_Click;
            deleteButton.Click += DeleteButton_Click;
            
            nameToolTip.SetToolTip(nameLabel, "Введите название отдела (обязательно)");
            descriptionToolTip.SetToolTip(descriptionLabel, "Описание отдела (необязательно)");
            
            departmentsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            departmentsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            departmentsDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            departmentsDataGridView.ColumnHeadersHeight = 40;
            departmentsDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            departmentsDataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
            departmentsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
            departmentsDataGridView.RowHeadersVisible = false;
            departmentsDataGridView.EnableHeadersVisualStyles = false;
            departmentsDataGridView.Font = new Font("Segoe UI", 10);
            
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }
        
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void LoadData()
        {
            var departments = _dataService.GetDepartments();
            departmentsDataGridView.DataSource = departments;
            
            if (departments.Any() && IsHandleCreated)
            {
                BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (departmentsDataGridView.Columns.Contains("Id"))
                        {
                            departmentsDataGridView.Columns["Id"].Width = 50;
                            departmentsDataGridView.Columns["Id"].HeaderText = "ID";
                        }
                        if (departmentsDataGridView.Columns.Contains("Name"))
                            departmentsDataGridView.Columns["Name"].HeaderText = "Название";
                        if (departmentsDataGridView.Columns.Contains("Description"))
                            departmentsDataGridView.Columns["Description"].HeaderText = "Описание";
                        if (departmentsDataGridView.Columns.Contains("CreatedDate"))
                            departmentsDataGridView.Columns["CreatedDate"].HeaderText = "Дата создания";
                    }
                    catch
                    {
                    }
                }));
            }
        }
        
        private void GridView_SelectionChanged(object sender, EventArgs e)
        {
            if (departmentsDataGridView.SelectedRows.Count > 0)
            {
                _selectedDepartment = departmentsDataGridView.SelectedRows[0].DataBoundItem as Department;
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
                MessageBox.Show("Отдел успешно добавлен!", "Успех", 
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
                MessageBox.Show("Отдел успешно обновлен!", "Успех", 
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
                    MessageBox.Show("Невозможно удалить отдел с назначенной мебелью!", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                var result = MessageBox.Show($"Вы уверены, что хотите удалить '{_selectedDepartment.Name}'?", 
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    _dataService.DeleteDepartment(_selectedDepartment.Id);
                    LoadData();
                    ClearForm();
                    MessageBox.Show("Отдел успешно удален!", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название отдела!", "Ошибка проверки", 
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