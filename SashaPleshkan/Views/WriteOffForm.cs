using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FurnitureAccounting.Models;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public class WriteOffForm : Form
    {
        private DataService _dataService;
        private ComboBox furnitureComboBox;
        private TextBox reasonTextBox;
        private Label furnitureDetailsLabel;
        private Button writeOffButton;
        
        public WriteOffForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponents();
            LoadData();
        }
        
        private void InitializeComponents()
        {
            Text = "Write-off Furniture";
            Size = new Size(500, 350);
            StartPosition = FormStartPosition.CenterParent;
            
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 5,
                Padding = new Padding(20)
            };
            
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            
            mainPanel.Controls.Add(new Label { Text = "Select Furniture:", Anchor = AnchorStyles.Right }, 0, 0);
            furnitureComboBox = new ComboBox 
            { 
                Dock = DockStyle.Fill,
                DropDownStyle = ComboBoxStyle.DropDownList,
                DisplayMember = "DisplayText"
            };
            furnitureComboBox.SelectedIndexChanged += FurnitureComboBox_SelectedIndexChanged;
            mainPanel.Controls.Add(furnitureComboBox, 1, 0);
            
            mainPanel.Controls.Add(new Label { Text = "Details:", Anchor = AnchorStyles.Right | AnchorStyles.Top }, 0, 1);
            furnitureDetailsLabel = new Label 
            { 
                Text = "Select furniture to see details",
                ForeColor = Color.Gray,
                AutoSize = true,
                MaximumSize = new Size(300, 0)
            };
            mainPanel.Controls.Add(furnitureDetailsLabel, 1, 1);
            
            mainPanel.Controls.Add(new Label { Text = "Write-off Reason:", Anchor = AnchorStyles.Right | AnchorStyles.Top }, 0, 3);
            reasonTextBox = new TextBox 
            { 
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            mainPanel.Controls.Add(reasonTextBox, 1, 3);
            
            writeOffButton = new Button 
            { 
                Text = "Write-off",
                Width = 100,
                Height = 30,
                Enabled = false
            };
            writeOffButton.Click += WriteOffButton_Click;
            mainPanel.Controls.Add(writeOffButton, 1, 4);
            
            Controls.Add(mainPanel);
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
                            ? _dataService.GetDepartment(furniture.DepartmentId.Value)?.Name ?? "Not assigned"
                            : "Not assigned";
                            
                        furnitureDetailsLabel.Text = $"Type: {furniture.Type}\n" +
                                                   $"Price: ${furniture.Price:N2}\n" +
                                                   $"Purchase Date: {furniture.PurchaseDate:d}\n" +
                                                   $"Department: {department}";
                        furnitureDetailsLabel.ForeColor = Color.Black;
                        writeOffButton.Enabled = true;
                    }
                }
            }
            else
            {
                furnitureDetailsLabel.Text = "Select furniture to see details";
                furnitureDetailsLabel.ForeColor = Color.Gray;
                writeOffButton.Enabled = false;
            }
        }
        
        private void WriteOffButton_Click(object sender, EventArgs e)
        {
            if (furnitureComboBox.SelectedItem == null)
                return;
                
            if (string.IsNullOrWhiteSpace(reasonTextBox.Text))
            {
                MessageBox.Show("Please provide a reason for write-off!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reasonTextBox.Focus();
                return;
            }
            
            var result = MessageBox.Show("Are you sure you want to write-off this furniture?", 
                "Confirm Write-off", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
            if (result == DialogResult.Yes)
            {
                var selected = furnitureComboBox.SelectedItem as ComboBoxItem;
                if (selected != null)
                {
                    _dataService.WriteOffFurniture(selected.Id, reasonTextBox.Text.Trim());
                    
                    MessageBox.Show("Furniture written off successfully!", "Success", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    LoadData();
                    reasonTextBox.Clear();
                    furnitureDetailsLabel.Text = "Select furniture to see details";
                    furnitureDetailsLabel.ForeColor = Color.Gray;
                    writeOffButton.Enabled = false;
                }
            }
        }
    }
}