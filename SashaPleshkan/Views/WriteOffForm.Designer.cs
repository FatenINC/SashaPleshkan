namespace FurnitureAccounting.Views
{
    partial class WriteOffForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.furnitureLabel = new System.Windows.Forms.Label();
            this.furnitureComboBox = new System.Windows.Forms.ComboBox();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.reasonTextBox = new System.Windows.Forms.TextBox();
            this.writeOffButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();

            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.furnitureLabel, 0, 0);
            this.mainPanel.Controls.Add(this.furnitureComboBox, 1, 0);
            this.mainPanel.Controls.Add(this.detailsLabel, 1, 1);
            this.mainPanel.Controls.Add(this.reasonLabel, 0, 2);
            this.mainPanel.Controls.Add(this.reasonTextBox, 1, 2);
            this.mainPanel.Controls.Add(this.writeOffButton, 1, 3);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(20, 20);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 4;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Size = new System.Drawing.Size(460, 310);
            this.mainPanel.TabIndex = 0;

            this.furnitureLabel.AutoSize = true;
            this.furnitureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.furnitureLabel.Location = new System.Drawing.Point(3, 0);
            this.furnitureLabel.Name = "furnitureLabel";
            this.furnitureLabel.Size = new System.Drawing.Size(144, 40);
            this.furnitureLabel.TabIndex = 0;
            this.furnitureLabel.Text = "Мебель для списания:";
            this.furnitureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.furnitureComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.furnitureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.furnitureComboBox.FormattingEnabled = true;
            this.furnitureComboBox.Location = new System.Drawing.Point(153, 8);
            this.furnitureComboBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.furnitureComboBox.Name = "furnitureComboBox";
            this.furnitureComboBox.Size = new System.Drawing.Size(304, 23);
            this.furnitureComboBox.TabIndex = 1;

            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsLabel.ForeColor = System.Drawing.Color.Gray;
            this.detailsLabel.Location = new System.Drawing.Point(153, 40);
            this.detailsLabel.MaximumSize = new System.Drawing.Size(300, 0);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(300, 60);
            this.detailsLabel.TabIndex = 2;
            this.detailsLabel.Text = "Выберите мебель для просмотра деталей";

            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reasonLabel.Location = new System.Drawing.Point(3, 100);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(144, 120);
            this.reasonLabel.TabIndex = 3;
            this.reasonLabel.Text = "Причина списания:";

            this.reasonTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reasonTextBox.Location = new System.Drawing.Point(153, 103);
            this.reasonTextBox.Multiline = true;
            this.reasonTextBox.Name = "reasonTextBox";
            this.reasonTextBox.Size = new System.Drawing.Size(304, 114);
            this.reasonTextBox.TabIndex = 4;

            this.writeOffButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.writeOffButton.Location = new System.Drawing.Point(357, 277);
            this.writeOffButton.Name = "writeOffButton";
            this.writeOffButton.Size = new System.Drawing.Size(100, 30);
            this.writeOffButton.TabIndex = 5;
            this.writeOffButton.Text = "Списать";
            this.writeOffButton.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WriteOffForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Списание мебели";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Label furnitureLabel;
        private System.Windows.Forms.ComboBox furnitureComboBox;
        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.TextBox reasonTextBox;
        private System.Windows.Forms.Button writeOffButton;
    }
}