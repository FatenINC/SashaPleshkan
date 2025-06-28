namespace FurnitureAccounting.Views
{
    partial class FurnitureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.furnitureDataGridView = new System.Windows.Forms.DataGridView();
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.inputLayout = new System.Windows.Forms.TableLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.inventoryLabel = new System.Windows.Forms.Label();
            this.inventoryTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dateLabel = new System.Windows.Forms.Label();
            this.purchaseDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.showWrittenOffCheckBox = new System.Windows.Forms.CheckBox();
            this.buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.furnitureDataGridView)).BeginInit();
            this.inputGroupBox.SuspendLayout();
            this.inputLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.furnitureDataGridView, 0, 0);
            this.mainPanel.Controls.Add(this.inputGroupBox, 0, 1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 2;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.mainPanel.Size = new System.Drawing.Size(800, 600);
            this.mainPanel.TabIndex = 0;
            // 
            // furnitureDataGridView
            // 
            this.furnitureDataGridView.AllowUserToAddRows = false;
            this.furnitureDataGridView.AllowUserToDeleteRows = false;
            this.furnitureDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.furnitureDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.furnitureDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.furnitureDataGridView.Location = new System.Drawing.Point(3, 3);
            this.furnitureDataGridView.Name = "furnitureDataGridView";
            this.furnitureDataGridView.ReadOnly = true;
            this.furnitureDataGridView.RowTemplate.Height = 25;
            this.furnitureDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.furnitureDataGridView.Size = new System.Drawing.Size(794, 394);
            this.furnitureDataGridView.TabIndex = 0;
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Controls.Add(this.inputLayout);
            this.inputGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputGroupBox.Location = new System.Drawing.Point(3, 403);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(794, 194);
            this.inputGroupBox.TabIndex = 1;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Добавить/Редактировать мебель";
            // 
            // inputLayout
            // 
            this.inputLayout.ColumnCount = 6;
            this.inputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.inputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.inputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.inputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.inputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.inputLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.inputLayout.Controls.Add(this.nameLabel, 0, 0);
            this.inputLayout.Controls.Add(this.nameTextBox, 1, 0);
            this.inputLayout.Controls.Add(this.typeLabel, 2, 0);
            this.inputLayout.Controls.Add(this.typeComboBox, 3, 0);
            this.inputLayout.Controls.Add(this.inventoryLabel, 4, 0);
            this.inputLayout.Controls.Add(this.inventoryTextBox, 5, 0);
            this.inputLayout.Controls.Add(this.priceLabel, 0, 1);
            this.inputLayout.Controls.Add(this.priceNumericUpDown, 1, 1);
            this.inputLayout.Controls.Add(this.dateLabel, 2, 1);
            this.inputLayout.Controls.Add(this.purchaseDateTimePicker, 3, 1);
            this.inputLayout.Controls.Add(this.showWrittenOffCheckBox, 4, 1);
            this.inputLayout.Controls.Add(this.buttonPanel, 0, 2);
            this.inputLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputLayout.Location = new System.Drawing.Point(3, 19);
            this.inputLayout.Name = "inputLayout";
            this.inputLayout.Padding = new System.Windows.Forms.Padding(10);
            this.inputLayout.RowCount = 3;
            this.inputLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.inputLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.inputLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.inputLayout.SetColumnSpan(this.showWrittenOffCheckBox, 2);
            this.inputLayout.SetColumnSpan(this.buttonPanel, 6);
            this.inputLayout.Size = new System.Drawing.Size(788, 172);
            this.inputLayout.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(36, 22);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(71, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Название:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(113, 18);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(150, 23);
            this.nameTextBox.TabIndex = 1;
            // 
            // typeLabel
            // 
            this.typeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(337, 22);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(36, 15);
            this.typeLabel.TabIndex = 2;
            this.typeLabel.Text = "Тип:";
            // 
            // typeComboBox
            // 
            this.typeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(379, 18);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(150, 23);
            this.typeComboBox.TabIndex = 3;
            // 
            // inventoryLabel
            // 
            this.inventoryLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.inventoryLabel.AutoSize = true;
            this.inventoryLabel.Location = new System.Drawing.Point(550, 22);
            this.inventoryLabel.Name = "inventoryLabel";
            this.inventoryLabel.Size = new System.Drawing.Size(79, 15);
            this.inventoryLabel.TabIndex = 4;
            this.inventoryLabel.Text = "Инв. номер:";
            // 
            // inventoryTextBox
            // 
            this.inventoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.inventoryTextBox.Location = new System.Drawing.Point(635, 18);
            this.inventoryTextBox.Name = "inventoryTextBox";
            this.inventoryTextBox.Size = new System.Drawing.Size(140, 23);
            this.inventoryTextBox.TabIndex = 5;
            // 
            // priceLabel
            // 
            this.priceLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(65, 62);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(42, 15);
            this.priceLabel.TabIndex = 6;
            this.priceLabel.Text = "Цена:";
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.priceNumericUpDown.DecimalPlaces = 2;
            this.priceNumericUpDown.Location = new System.Drawing.Point(113, 58);
            this.priceNumericUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(150, 23);
            this.priceNumericUpDown.TabIndex = 7;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(276, 62);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(97, 15);
            this.dateLabel.TabIndex = 8;
            this.dateLabel.Text = "Дата покупки:";
            // 
            // purchaseDateTimePicker
            // 
            this.purchaseDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.purchaseDateTimePicker.Location = new System.Drawing.Point(379, 58);
            this.purchaseDateTimePicker.Name = "purchaseDateTimePicker";
            this.purchaseDateTimePicker.Size = new System.Drawing.Size(150, 23);
            this.purchaseDateTimePicker.TabIndex = 9;
            // 
            // showWrittenOffCheckBox
            // 
            this.showWrittenOffCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.showWrittenOffCheckBox.AutoSize = true;
            this.showWrittenOffCheckBox.Location = new System.Drawing.Point(535, 60);
            this.showWrittenOffCheckBox.Name = "showWrittenOffCheckBox";
            this.showWrittenOffCheckBox.Size = new System.Drawing.Size(152, 19);
            this.showWrittenOffCheckBox.TabIndex = 10;
            this.showWrittenOffCheckBox.Text = "Показать списанные";
            this.showWrittenOffCheckBox.UseVisualStyleBackColor = true;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.addButton);
            this.buttonPanel.Controls.Add(this.updateButton);
            this.buttonPanel.Controls.Add(this.deleteButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(13, 93);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(762, 66);
            this.buttonPanel.TabIndex = 11;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(3, 3);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 30);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(109, 3);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(100, 30);
            this.updateButton.TabIndex = 1;
            this.updateButton.Text = "Изменить";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(215, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(100, 30);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // FurnitureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.mainPanel);
            this.Name = "FurnitureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление мебелью";
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.furnitureDataGridView)).EndInit();
            this.inputGroupBox.ResumeLayout(false);
            this.inputLayout.ResumeLayout(false);
            this.inputLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.DataGridView furnitureDataGridView;
        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.TableLayoutPanel inputLayout;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label inventoryLabel;
        private System.Windows.Forms.TextBox inventoryTextBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.NumericUpDown priceNumericUpDown;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.DateTimePicker purchaseDateTimePicker;
        private System.Windows.Forms.CheckBox showWrittenOffCheckBox;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
    }
}