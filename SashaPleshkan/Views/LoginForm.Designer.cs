namespace FurnitureAccounting.Views
{
    partial class LoginForm
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
            mainPanel = new Panel();
            titleLabel = new Label();
            iconLabel = new Label();
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            passwordLabel = new Label();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            footerLabel = new Label();
            mainPanel.SuspendLayout();
            SuspendLayout();

            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(titleLabel);
            mainPanel.Controls.Add(iconLabel);
            mainPanel.Controls.Add(usernameLabel);
            mainPanel.Controls.Add(usernameTextBox);
            mainPanel.Controls.Add(passwordLabel);
            mainPanel.Controls.Add(passwordTextBox);
            mainPanel.Controls.Add(loginButton);
            mainPanel.Location = new Point(75, 100);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(300, 350);
            mainPanel.TabIndex = 0;

            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.FromArgb(52, 152, 219);
            titleLabel.Location = new Point(50, 100);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(184, 37);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Учет мебели";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;

            iconLabel.Font = new Font("Segoe UI", 48F, FontStyle.Regular, GraphicsUnit.Point);
            iconLabel.Location = new Point(100, 20);
            iconLabel.Name = "iconLabel";
            iconLabel.Size = new Size(100, 80);
            iconLabel.TabIndex = 1;
            iconLabel.Text = "\U0001fa91";
            iconLabel.TextAlign = ContentAlignment.MiddleCenter;

            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            usernameLabel.ForeColor = Color.FromArgb(64, 64, 64);
            usernameLabel.Location = new Point(50, 160);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(125, 19);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Имя пользователя";

            usernameTextBox.BorderStyle = BorderStyle.FixedSingle;
            usernameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            usernameTextBox.Location = new Point(50, 182);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(200, 29);
            usernameTextBox.TabIndex = 3;

            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            passwordLabel.ForeColor = Color.FromArgb(64, 64, 64);
            passwordLabel.Location = new Point(50, 220);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(56, 19);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Пароль";

            passwordTextBox.BorderStyle = BorderStyle.FixedSingle;
            passwordTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            passwordTextBox.Location = new Point(50, 242);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '•';
            passwordTextBox.Size = new Size(200, 29);
            passwordTextBox.TabIndex = 5;

            loginButton.BackColor = Color.FromArgb(52, 152, 219);
            loginButton.Cursor = Cursors.Hand;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(50, 290);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(200, 40);
            loginButton.TabIndex = 6;
            loginButton.Text = "Войти";
            loginButton.UseVisualStyleBackColor = false;

            footerLabel.AutoSize = true;
            footerLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            footerLabel.ForeColor = Color.White;
            footerLabel.Location = new Point(165, 500);
            footerLabel.Name = "footerLabel";
            footerLabel.Size = new Size(114, 13);
            footerLabel.TabIndex = 1;
            footerLabel.Text = "© 2025 Учет мебели";
            footerLabel.TextAlign = ContentAlignment.MiddleCenter;
            footerLabel.Click += footerLabel_Click;

            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 152, 219);
            ClientSize = new Size(450, 550);
            Controls.Add(footerLabel);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label iconLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label footerLabel;
    }
}