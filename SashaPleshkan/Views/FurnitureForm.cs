using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Models;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public class FurnitureForm : Form
    {
        private DataService _dataService;
        private DataGridView gridView;
        private TextBox nameTextBox;
        private ComboBox typeComboBox;
        private TextBox inventoryNumberTextBox;
        private NumericUpDown priceNumeric;
        private DateTimePicker purchaseDatePicker;
        private CheckBox showWrittenOffCheckBox;
        private Button addButton;
        private Button updateButton;
        private Button deleteButton;
        private Furniture _selectedFurniture;
        
        public FurnitureForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponents();
        }
        
        private void InitializeComponents()
        {
            Text = "Управление мебелью";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterParent;
            Load += FurnitureForm_Load;
            
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(10)
            };
            
            var inputPanel = new GroupBox
            {
                Text = "Данные мебели",
                Height = 200,
                Dock = DockStyle.Top
            };
            
            var inputLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 4,
                Padding = new Padding(5)
            };
            
            inputLayout.Controls.Add(new Label { Text = "Название:", Anchor = AnchorStyles.Right }, 0, 0);
            nameTextBox = new TextBox { Dock = DockStyle.Fill };
            inputLayout.Controls.Add(nameTextBox, 1, 0);
            
            inputLayout.Controls.Add(new Label { Text = "Тип:", Anchor = AnchorStyles.Right }, 2, 0);
            typeComboBox = new ComboBox 
            { 
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            typeComboBox.Items.AddRange(new[] { "Стол", "Стул", "Шкаф", "Полка", "Письменный стол", "Другое" });
            inputLayout.Controls.Add(typeComboBox, 3, 0);
            
            inputLayout.Controls.Add(new Label { Text = "Инв. номер:", Anchor = AnchorStyles.Right }, 0, 1);
            inventoryNumberTextBox = new TextBox { Dock = DockStyle.Fill };
            inputLayout.Controls.Add(inventoryNumberTextBox, 1, 1);
            
            inputLayout.Controls.Add(new Label { Text = "Цена:", Anchor = AnchorStyles.Right }, 2, 1);
            priceNumeric = new NumericUpDown 
            { 
                Dock = DockStyle.Fill,
                DecimalPlaces = 2,
                Maximum = 999999,
                Minimum = 0
            };
            inputLayout.Controls.Add(priceNumeric, 3, 1);
            
            inputLayout.Controls.Add(new Label { Text = "Дата покупки:", Anchor = AnchorStyles.Right }, 0, 2);
            purchaseDatePicker = new DateTimePicker { Dock = DockStyle.Fill };
            inputLayout.Controls.Add(purchaseDatePicker, 1, 2);
            
            showWrittenOffCheckBox = new CheckBox 
            { 
                Text = "Показать списанные",
                Anchor = AnchorStyles.Left
            };
            showWrittenOffCheckBox.CheckedChanged += (s, e) => LoadData();
            inputLayout.Controls.Add(showWrittenOffCheckBox, 2, 2);
            inputLayout.SetColumnSpan(showWrittenOffCheckBox, 2);
            
            var buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                Dock = DockStyle.Fill
            };
            
            addButton = new Button { Text = "Добавить", Width = 100 };
            addButton.Click += AddButton_Click;
            updateButton = new Button { Text = "Изменить", Width = 100, Enabled = false };
            updateButton.Click += UpdateButton_Click;
            deleteButton = new Button { Text = "Удалить", Width = 100, Enabled = false };
            deleteButton.Click += DeleteButton_Click;
            
            buttonPanel.Controls.Add(addButton);
            buttonPanel.Controls.Add(updateButton);
            buttonPanel.Controls.Add(deleteButton);
            
            inputLayout.Controls.Add(buttonPanel, 1, 3);
            inputLayout.SetColumnSpan(buttonPanel, 3);
            
            inputPanel.Controls.Add(inputLayout);
            
            gridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true
            };
            gridView.SelectionChanged += GridView_SelectionChanged;
            
            mainPanel.Controls.Add(inputPanel, 0, 0);
            mainPanel.Controls.Add(gridView, 0, 1);
            
            Controls.Add(mainPanel);
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
            
            gridView.DataSource = null;
            gridView.DataSource = furniture;
            
            // Use BeginInvoke only if handle is created
            if (furniture.Any() && IsHandleCreated)
            {
                BeginInvoke(new Action(() =>
                {
                    try
                    {
                        if (gridView.Columns.Contains("Id"))
                            gridView.Columns["Id"].Width = 50;
                        if (gridView.Columns.Contains("DepartmentId"))
                            gridView.Columns["DepartmentId"].Visible = false;
                        if (gridView.Columns.Contains("WriteOffReason"))
                            gridView.Columns["WriteOffReason"].Visible = false;
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
                _selectedFurniture = gridView.SelectedRows[0].DataBoundItem as Furniture;
                if (_selectedFurniture != null)
                {
                    nameTextBox.Text = _selectedFurniture.Name;
                    typeComboBox.Text = _selectedFurniture.Type;
                    inventoryNumberTextBox.Text = _selectedFurniture.InventoryNumber;
                    priceNumeric.Value = _selectedFurniture.Price;
                    purchaseDatePicker.Value = _selectedFurniture.PurchaseDate;
                    
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
                    InventoryNumber = inventoryNumberTextBox.Text.Trim(),
                    Price = priceNumeric.Value,
                    PurchaseDate = purchaseDatePicker.Value
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
                _selectedFurniture.InventoryNumber = inventoryNumberTextBox.Text.Trim();
                _selectedFurniture.Price = priceNumeric.Value;
                _selectedFurniture.PurchaseDate = purchaseDatePicker.Value;
                
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
            
            if (string.IsNullOrWhiteSpace(inventoryNumberTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите инвентарный номер!", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                inventoryNumberTextBox.Focus();
                return false;
            }
            
            var existingFurniture = _dataService.GetFurniture()
                .FirstOrDefault(f => f.InventoryNumber == inventoryNumberTextBox.Text.Trim() 
                    && f.Id != (_selectedFurniture?.Id ?? 0));
                    
            if (existingFurniture != null)
            {
                MessageBox.Show("Инвентарный номер уже существует!", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                inventoryNumberTextBox.Focus();
                return false;
            }
            
            return true;
        }
        
        private void ClearForm()
        {
            nameTextBox.Clear();
            typeComboBox.SelectedIndex = -1;
            inventoryNumberTextBox.Clear();
            priceNumeric.Value = 0;
            purchaseDatePicker.Value = DateTime.Now;
            _selectedFurniture = null;
            updateButton.Enabled = false;
            deleteButton.Enabled = false;
        }
    }
}