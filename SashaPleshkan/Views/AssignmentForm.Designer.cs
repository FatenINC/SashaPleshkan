namespace FurnitureAccounting.Views
{
    partial class AssignmentForm
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
            this.currentAssignmentTitleLabel = new System.Windows.Forms.Label();
            this.currentAssignmentLabel = new System.Windows.Forms.Label();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.buttonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.assignButton = new System.Windows.Forms.Button();
            this.unassignButton = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();

            this.mainPanel.ColumnCount = 2;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.furnitureLabel, 0, 0);
            this.mainPanel.Controls.Add(this.furnitureComboBox, 1, 0);
            this.mainPanel.Controls.Add(this.currentAssignmentTitleLabel, 0, 1);
            this.mainPanel.Controls.Add(this.currentAssignmentLabel, 1, 1);
            this.mainPanel.Controls.Add(this.departmentLabel, 0, 2);
            this.mainPanel.Controls.Add(this.departmentComboBox, 1, 2);
            this.mainPanel.Controls.Add(this.buttonPanel, 0, 3);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(20, 20);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 4;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.SetColumnSpan(this.buttonPanel, 2);
            this.mainPanel.Size = new System.Drawing.Size(460, 260);
            this.mainPanel.TabIndex = 0;

            this.furnitureLabel.AutoSize = true;
            this.furnitureLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.furnitureLabel.Location = new System.Drawing.Point(3, 0);
            this.furnitureLabel.Name = "furnitureLabel";
            this.furnitureLabel.Size = new System.Drawing.Size(144, 40);
            this.furnitureLabel.TabIndex = 0;
            this.furnitureLabel.Text = "Мебель:";
            this.furnitureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.furnitureComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.furnitureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.furnitureComboBox.FormattingEnabled = true;
            this.furnitureComboBox.Location = new System.Drawing.Point(153, 8);
            this.furnitureComboBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.furnitureComboBox.Name = "furnitureComboBox";
            this.furnitureComboBox.Size = new System.Drawing.Size(304, 23);
            this.furnitureComboBox.TabIndex = 1;

            this.currentAssignmentTitleLabel.AutoSize = true;
            this.currentAssignmentTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentAssignmentTitleLabel.Location = new System.Drawing.Point(3, 40);
            this.currentAssignmentTitleLabel.Name = "currentAssignmentTitleLabel";
            this.currentAssignmentTitleLabel.Size = new System.Drawing.Size(144, 40);
            this.currentAssignmentTitleLabel.TabIndex = 2;
            this.currentAssignmentTitleLabel.Text = "Текущее назначение:";
            this.currentAssignmentTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.currentAssignmentLabel.AutoSize = true;
            this.currentAssignmentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currentAssignmentLabel.ForeColor = System.Drawing.Color.Gray;
            this.currentAssignmentLabel.Location = new System.Drawing.Point(153, 40);
            this.currentAssignmentLabel.Name = "currentAssignmentLabel";
            this.currentAssignmentLabel.Size = new System.Drawing.Size(304, 40);
            this.currentAssignmentLabel.TabIndex = 3;
            this.currentAssignmentLabel.Text = "Не назначено";
            this.currentAssignmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentLabel.Location = new System.Drawing.Point(3, 80);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(144, 40);
            this.departmentLabel.TabIndex = 4;
            this.departmentLabel.Text = "Назначить в отдел:";
            this.departmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.departmentComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(153, 88);
            this.departmentComboBox.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(304, 23);
            this.departmentComboBox.TabIndex = 5;

            this.buttonPanel.Controls.Add(this.assignButton);
            this.buttonPanel.Controls.Add(this.unassignButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonPanel.Location = new System.Drawing.Point(3, 217);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(454, 40);
            this.buttonPanel.TabIndex = 6;

            this.assignButton.Location = new System.Drawing.Point(376, 3);
            this.assignButton.Name = "assignButton";
            this.assignButton.Size = new System.Drawing.Size(75, 30);
            this.assignButton.TabIndex = 0;
            this.assignButton.Text = "Назначить";
            this.assignButton.UseVisualStyleBackColor = true;

            this.unassignButton.Location = new System.Drawing.Point(255, 3);
            this.unassignButton.Name = "unassignButton";
            this.unassignButton.Size = new System.Drawing.Size(115, 30);
            this.unassignButton.TabIndex = 1;
            this.unassignButton.Text = "Отменить назначение";
            this.unassignButton.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignmentForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Назначение мебели";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Label furnitureLabel;
        private System.Windows.Forms.ComboBox furnitureComboBox;
        private System.Windows.Forms.Label currentAssignmentTitleLabel;
        private System.Windows.Forms.Label currentAssignmentLabel;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Button assignButton;
        private System.Windows.Forms.Button unassignButton;
    }
}