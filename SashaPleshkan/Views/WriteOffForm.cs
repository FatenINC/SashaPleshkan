using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Models;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public partial class WriteOffForm : Form
    {
        private DataService _dataService;
        
        public WriteOffForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            SetupEventHandlers();
            LoadData();
        }
        
        private void SetupEventHandlers()
        {
            furnitureComboBox.SelectedIndexChanged += FurnitureComboBox_SelectedIndexChanged;
            writeOffButton.Click += WriteOffButton_Click;
            
            writeOffButton.Enabled = false;
            detailsLabel.Text = "Выберите мебель для просмотра деталей";
            detailsLabel.ForeColor = Color.Gray;
        }
        
        private void LoadData()
        {
            var furniture = _dataService.GetFurniture()
                .Where(f => !f.IsWrittenOff)
                .Select(f => new ComboBoxItem
                {
                    Id = f.Id,
                    DisplayText = $"{f.Name} ({f.InventoryNumber})"
                })
                .ToList();
                
            furnitureComboBox.DataSource = furniture;
            furnitureComboBox.DisplayMember = "DisplayText";
            furnitureComboBox.ValueMember = "Id";
        }
        
        private void FurnitureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (furnitureComboBox.SelectedItem != null)
            {
                var selected = furnitureComboBox.SelectedItem as ComboBoxItem;
                if (selected != null)
                {
                    var furniture = _dataService.GetFurnitureItem(selected.Id);
                    
                    if (furniture != null)
                    {
                        var department = furniture.DepartmentId.HasValue 
                            ? _dataService.GetDepartment(furniture.DepartmentId.Value)?.Name ?? "Не назначен"
                            : "Не назначен";
                            
                        detailsLabel.Text = $"Тип: {furniture.Type}\n" +
                                                   $"Цена: ${furniture.Price:N2}\n" +
                                                   $"Дата покупки: {furniture.PurchaseDate:d}\n" +
                                                   $"Отдел: {department}";
                        detailsLabel.ForeColor = Color.Black;
                        writeOffButton.Enabled = true;
                    }
                }
            }
            else
            {
                detailsLabel.Text = "Выберите мебель для просмотра деталей";
                detailsLabel.ForeColor = Color.Gray;
                writeOffButton.Enabled = false;
            }
        }
        
        private void WriteOffButton_Click(object sender, EventArgs e)
        {
            if (furnitureComboBox.SelectedItem == null)
                return;
                
            if (string.IsNullOrWhiteSpace(reasonTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, укажите причину списания!", "Ошибка валидации", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reasonTextBox.Focus();
                return;
            }
            
            var result = MessageBox.Show("Вы уверены, что хотите списать эту мебель?", 
                "Подтвердите списание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                var selected = furnitureComboBox.SelectedItem as ComboBoxItem;
                if (selected != null)
                {
                    _dataService.WriteOffFurniture(selected.Id, reasonTextBox.Text.Trim());
                    
                    MessageBox.Show("Мебель успешно списана!", "Успех", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    LoadData();
                    reasonTextBox.Clear();
                    detailsLabel.Text = "Выберите мебель для просмотра деталей";
                    detailsLabel.ForeColor = Color.Gray;
                    writeOffButton.Enabled = false;
                }
            }
        }
    }
}