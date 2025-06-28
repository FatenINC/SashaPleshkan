namespace FurnitureAccounting.Views
{
    partial class ReportForm
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
            this.topPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.reportTypeLabel = new System.Windows.Forms.Label();
            this.reportTypeComboBox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.printButton = new System.Windows.Forms.Button();
            this.reportRichTextBox = new System.Windows.Forms.RichTextBox();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.mainPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.topPanel, 0, 0);
            this.mainPanel.Controls.Add(this.reportRichTextBox, 0, 1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 2;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Size = new System.Drawing.Size(800, 600);
            this.mainPanel.TabIndex = 0;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.reportTypeLabel);
            this.topPanel.Controls.Add(this.reportTypeComboBox);
            this.topPanel.Controls.Add(this.generateButton);
            this.topPanel.Controls.Add(this.saveButton);
            this.topPanel.Controls.Add(this.printButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(5);
            this.topPanel.Size = new System.Drawing.Size(794, 44);
            this.topPanel.TabIndex = 0;
            // 
            // reportTypeLabel
            // 
            this.reportTypeLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.reportTypeLabel.AutoSize = true;
            this.reportTypeLabel.Location = new System.Drawing.Point(8, 14);
            this.reportTypeLabel.Name = "reportTypeLabel";
            this.reportTypeLabel.Size = new System.Drawing.Size(72, 15);
            this.reportTypeLabel.TabIndex = 0;
            this.reportTypeLabel.Text = "Тип отчета:";
            // 
            // reportTypeComboBox
            // 
            this.reportTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.reportTypeComboBox.FormattingEnabled = true;
            this.reportTypeComboBox.Location = new System.Drawing.Point(86, 8);
            this.reportTypeComboBox.Name = "reportTypeComboBox";
            this.reportTypeComboBox.Size = new System.Drawing.Size(250, 23);
            this.reportTypeComboBox.TabIndex = 1;
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(342, 8);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 25);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Сформировать";
            this.generateButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(448, 8);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 25);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // printButton
            // 
            this.printButton.Enabled = false;
            this.printButton.Location = new System.Drawing.Point(554, 8);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(100, 25);
            this.printButton.TabIndex = 4;
            this.printButton.Text = "Печать";
            this.printButton.UseVisualStyleBackColor = true;
            // 
            // reportRichTextBox
            // 
            this.reportRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportRichTextBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reportRichTextBox.Location = new System.Drawing.Point(3, 53);
            this.reportRichTextBox.Name = "reportRichTextBox";
            this.reportRichTextBox.ReadOnly = true;
            this.reportRichTextBox.Size = new System.Drawing.Size(794, 544);
            this.reportRichTextBox.TabIndex = 1;
            this.reportRichTextBox.Text = "";
            this.reportRichTextBox.WordWrap = false;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.mainPanel);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчеты";
            this.mainPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel topPanel;
        private System.Windows.Forms.Label reportTypeLabel;
        private System.Windows.Forms.ComboBox reportTypeComboBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.RichTextBox reportRichTextBox;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}