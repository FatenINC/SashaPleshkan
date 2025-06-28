namespace FurnitureAccounting.Views
{
    partial class LogsForm
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
            this.filterGroupBox = new System.Windows.Forms.GroupBox();
            this.filterLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.fromLabel = new System.Windows.Forms.Label();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toLabel = new System.Windows.Forms.Label();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.actionLabel = new System.Windows.Forms.Label();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.logsDataGridView = new System.Windows.Forms.DataGridView();
            this.mainPanel.SuspendLayout();
            this.filterGroupBox.SuspendLayout();
            this.filterLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.filterGroupBox, 0, 0);
            this.mainPanel.Controls.Add(this.logsDataGridView, 0, 1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 2;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Size = new System.Drawing.Size(900, 600);
            this.mainPanel.TabIndex = 0;
            // 
            // filterGroupBox
            // 
            this.filterGroupBox.Controls.Add(this.filterLayout);
            this.filterGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterGroupBox.Location = new System.Drawing.Point(3, 3);
            this.filterGroupBox.Name = "filterGroupBox";
            this.filterGroupBox.Size = new System.Drawing.Size(894, 94);
            this.filterGroupBox.TabIndex = 0;
            this.filterGroupBox.TabStop = false;
            this.filterGroupBox.Text = "Фильтры";
            // 
            // filterLayout
            // 
            this.filterLayout.Controls.Add(this.fromLabel);
            this.filterLayout.Controls.Add(this.fromDateTimePicker);
            this.filterLayout.Controls.Add(this.toLabel);
            this.filterLayout.Controls.Add(this.toDateTimePicker);
            this.filterLayout.Controls.Add(this.actionLabel);
            this.filterLayout.Controls.Add(this.actionComboBox);
            this.filterLayout.Controls.Add(this.applyButton);
            this.filterLayout.Controls.Add(this.clearButton);
            this.filterLayout.Controls.Add(this.exportButton);
            this.filterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterLayout.Location = new System.Drawing.Point(3, 19);
            this.filterLayout.Name = "filterLayout";
            this.filterLayout.Padding = new System.Windows.Forms.Padding(10);
            this.filterLayout.Size = new System.Drawing.Size(888, 72);
            this.filterLayout.TabIndex = 0;
            // 
            // fromLabel
            // 
            this.fromLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fromLabel.AutoSize = true;
            this.fromLabel.Location = new System.Drawing.Point(13, 19);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(18, 15);
            this.fromLabel.TabIndex = 0;
            this.fromLabel.Text = "С:";
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDateTimePicker.Location = new System.Drawing.Point(37, 13);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(100, 23);
            this.fromDateTimePicker.TabIndex = 1;
            // 
            // toLabel
            // 
            this.toLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.toLabel.AutoSize = true;
            this.toLabel.Location = new System.Drawing.Point(143, 19);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(25, 15);
            this.toLabel.TabIndex = 2;
            this.toLabel.Text = "По:";
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDateTimePicker.Location = new System.Drawing.Point(174, 13);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(100, 23);
            this.toDateTimePicker.TabIndex = 3;
            // 
            // actionLabel
            // 
            this.actionLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(280, 19);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(62, 15);
            this.actionLabel.TabIndex = 4;
            this.actionLabel.Text = "Действие:";
            // 
            // actionComboBox
            // 
            this.actionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Location = new System.Drawing.Point(348, 13);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(150, 23);
            this.actionComboBox.TabIndex = 5;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(504, 13);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(80, 25);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(590, 13);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(80, 25);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(676, 13);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(100, 25);
            this.exportButton.TabIndex = 8;
            this.exportButton.Text = "Экспорт в Excel";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // logsDataGridView
            // 
            this.logsDataGridView.AllowUserToAddRows = false;
            this.logsDataGridView.AllowUserToDeleteRows = false;
            this.logsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.logsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsDataGridView.Location = new System.Drawing.Point(3, 103);
            this.logsDataGridView.Name = "logsDataGridView";
            this.logsDataGridView.ReadOnly = true;
            this.logsDataGridView.RowTemplate.Height = 25;
            this.logsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.logsDataGridView.Size = new System.Drawing.Size(894, 494);
            this.logsDataGridView.TabIndex = 1;
            // 
            // LogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.mainPanel);
            this.Name = "LogsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Журнал действий";
            this.mainPanel.ResumeLayout(false);
            this.filterGroupBox.ResumeLayout(false);
            this.filterLayout.ResumeLayout(false);
            this.filterLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.FlowLayoutPanel filterLayout;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.DataGridView logsDataGridView;
    }
}