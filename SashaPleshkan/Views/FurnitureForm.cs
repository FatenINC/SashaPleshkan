using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Models;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public partial class FurnitureForm : Form
    {
        private DataService _dataService;
        private Furniture _selectedFurniture;
        
        public FurnitureForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            SetupEventHandlers();
        }
        
        private void SetupEventHandlers()
        {
            Load += FurnitureForm_Load;
            furnitureDataGridView.SelectionChanged += GridView_SelectionChanged;
            addButton.Click += AddButton_Click;
            updateButton.Click += UpdateButton_Click;
            deleteButton.Click += DeleteButton_Click;
            showWrittenOffCheckBox.CheckedChanged += (s, e) => LoadData();
            
            // Add furniture types to combo box
            typeComboBox.Items.AddRange(new[] { "Стол", "Стул", "Шкаф", "Полка", "Письменный стол", "Другое" });
            
            // Set initial state
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }
        
        private void FurnitureForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void LoadData()
        {
            var furniture = _dataService.GetFurniture();
            
            if (!showWrittenOffCheckBox.Checked)
            {
                furniture = furniture.Where(f => !f.IsWrittenOff).ToList();
            }
            
            furnitureDataGridView.DataSource = null;
            furnitureDataGridView.DataSource = furniture;
            
            // Use BeginInvoke only if handle is created
            if (furniture.Any() && IsHandleCreated)
            {
                BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (furnitureDataGridView.Columns.Contains("Id"))
                        {
                            furnitureDataGridView.Columns["Id"].Width = 50;
                            furnitureDataGridView.Columns["Id"].HeaderText = "ID";
                        }
                        if (furnitureDataGridView.Columns.Contains("Name"))
                            furnitureDataGridView.Columns["Name"].HeaderText = "Название";
                        if (furnitureDataGridView.Columns.Contains("Type"))
                            furnitureDataGridView.Columns["Type"].HeaderText = "Тип";
                        if (furnitureDataGridView.Columns.Contains("InventoryNumber"))
                            furnitureDataGridView.Columns["InventoryNumber"].HeaderText = "Инв. номер";
                        if (furnitureDataGridView.Columns.Contains("Price"))
                            furnitureDataGridView.Columns["Price"].HeaderText = "Цена";
                        if (furnitureDataGridView.Columns.Contains("PurchaseDate"))
                            furnitureDataGridView.Columns["PurchaseDate"].HeaderText = "Дата покупки";
                        if (furnitureDataGridView.Columns.Contains("IsWrittenOff"))
                            furnitureDataGridView.Columns["IsWrittenOff"].HeaderText = "Списано";
                        if (furnitureDataGridView.Columns.Contains("WriteOffDate"))
                            furnitureDataGridView.Columns["WriteOffDate"].HeaderText = "Дата списания";
                        if (furnitureDataGridView.Columns.Contains("DepartmentId"))
                            furnitureDataGridView.Columns["DepartmentId"].Visible = false;
                        if (furnitureDataGridView.Columns.Contains("WriteOffReason"))
                            furnitureDataGridView.Columns["WriteOffReason"].Visible = false;
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
            if (furnitureDataGridView.SelectedRows.Count > 0)
            {
                _selectedFurniture = furnitureDataGridView.SelectedRows[0].DataBoundItem as Furniture;
                if (_selectedFurniture != null)
                {
                    nameTextBox.Text = _selectedFurniture.Name;
                    typeComboBox.Text = _selectedFurniture.Type;
                    inventoryTextBox.Text = _selectedFurniture.InventoryNumber;
                    priceNumericUpDown.Value = _selectedFurniture.Price;
                    purchaseDateTimePicker.Value = _selectedFurniture.PurchaseDate;
                    
                    updateButton.Enabled = !_selectedFurniture.IsWrittenOff;
                    deleteButton.Enabled = !_selectedFurniture.IsWrittenOff;
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
                var furniture = new Furniture
                {
                    Name = nameTextBox.Text.Trim(),
                    Type = typeComboBox.Text,
                    InventoryNumber = inventoryTextBox.Text.Trim(),
                    Price = priceNumericUpDown.Value,
                    PurchaseDate = purchaseDateTimePicker.Value
                };
                
                _dataService.AddFurniture(furniture);
                LoadData();
                ClearForm();
                MessageBox.Show("Мебель успешно добавлена!", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (_selectedFurniture != null && ValidateInput())
            {
                _selectedFurniture.Name = nameTextBox.Text.Trim();
                _selectedFurniture.Type = typeComboBox.Text;
                _selectedFurniture.InventoryNumber = inventoryTextBox.Text.Trim();
                _selectedFurniture.Price = priceNumericUpDown.Value;
                _selectedFurniture.PurchaseDate = purchaseDateTimePicker.Value;
                
                _dataService.UpdateFurniture(_selectedFurniture);
                LoadData();
                ClearForm();
                MessageBox.Show("Мебель успешно обновлена!", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (_selectedFurniture != null)
            {
                var result = MessageBox.Show($"Вы уверены, что хотите удалить '{_selectedFurniture.Name}'?", 
                    "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    
                if (result == DialogResult.Yes)
                {
                    _dataService.DeleteFurniture(_selectedFurniture.Id);
                    LoadData();
                    ClearForm();
                    MessageBox.Show("Мебель успешно удалена!", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите название мебели!", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(typeComboBox.Text))
            {
                MessageBox.Show("Пожалуйста, выберите тип мебели!", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                typeComboBox.Focus();
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(inventoryTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите инвентарный номер!", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                inventoryTextBox.Focus();
                return false;
            }
            
            var existingFurniture = _dataService.GetFurniture()
                .FirstOrDefault(f => f.InventoryNumber == inventoryTextBox.Text.Trim() 
                    && f.Id != (_selectedFurniture?.Id ?? 0));
                    
            if (existingFurniture != null)
            {
                MessageBox.Show("Инвентарный номер уже существует!", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                inventoryTextBox.Focus();
                return false;
            }
            
            return true;
        }
        
        private void ClearForm()
        {
            nameTextBox.Clear();
            typeComboBox.SelectedIndex = -1;
            inventoryTextBox.Clear();
            priceNumericUpDown.Value = 0;
            purchaseDateTimePicker.Value = DateTime.Now;
            _selectedFurniture = null;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }
    }
}