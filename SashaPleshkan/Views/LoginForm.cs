using System;
using System.Drawing;
using System.Windows.Forms;

namespace FurnitureAccounting.Views
{
    public class LoginForm : Form
    {
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label titleLabel;
        private Label subtitleLabel;
        private Panel loginPanel;
        
        public string Username { get; private set; }
        
        public LoginForm()
        {
            InitializeComponents();
        }
        
        private void InitializeComponents()
        {
            Text = "Furniture Accounting - Login";
            Size = new Size(450, 550);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(52, 152, 219);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            
            // Create central login panel
            loginPanel = new Panel
            {
                Width = 350,
                Height = 400,
                BackColor = Color.White,
                Location = new Point(50, 60)
            };
            
            // Add shadow effect
            loginPanel.Paint += (s, e) =>
            {
                var rect = new Rectangle(5, 5, loginPanel.Width - 5, loginPanel.Height - 5);
                using (var brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };
            
            // Icon/Logo
            var iconLabel = new Label
            {
                Text = "🪑",
                Font = new Font("Segoe UI", 48),
                AutoSize = true,
                Location = new Point(130, 30)
            };
            loginPanel.Controls.Add(iconLabel);
            
            // Title
            titleLabel = new Label
            {
                Text = "Welcome Back!",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80),
                AutoSize = true,
                Location = new Point(80, 120)
            };
            loginPanel.Controls.Add(titleLabel);
            
            // Subtitle
            subtitleLabel = new Label
            {
                Text = "Please login to your account",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(90, 155)
            };
            loginPanel.Controls.Add(subtitleLabel);
            
            // Username field
            var usernameLabel = new Label
            {
                Text = "Username",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(50, 200),
                AutoSize = true
            };
            loginPanel.Controls.Add(usernameLabel);
            
            usernameTextBox = new TextBox
            {
                Width = 250,
                Height = 35,
                Location = new Point(50, 225),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle
            };
            usernameTextBox.Text = Environment.UserName;
            loginPanel.Controls.Add(usernameTextBox);
            
            // Password field
            var passwordLabel = new Label
            {
                Text = "Password",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(44, 62, 80),
                Location = new Point(50, 270),
                AutoSize = true
            };
            loginPanel.Controls.Add(passwordLabel);
            
            passwordTextBox = new TextBox
            {
                Width = 250,
                Height = 35,
                Location = new Point(50, 295),
                Font = new Font("Segoe UI", 12),
                BorderStyle = BorderStyle.FixedSingle,
                PasswordChar = '•'
            };
            passwordTextBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    LoginButton_Click(s, e);
            };
            loginPanel.Controls.Add(passwordTextBox);
            
            // Login button
            loginButton = new Button
            {
                Text = "LOGIN",
                Width = 250,
                Height = 45,
                Location = new Point(50, 350),
                BackColor = Color.FromArgb(52, 152, 219),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Click += LoginButton_Click;
            loginButton.MouseEnter += (s, e) => loginButton.BackColor = Color.FromArgb(41, 128, 185);
            loginButton.MouseLeave += (s, e) => loginButton.BackColor = Color.FromArgb(52, 152, 219);
            loginPanel.Controls.Add(loginButton);
            
            Controls.Add(loginPanel);
            
            // Footer
            var footerLabel = new Label
            {
                Text = "Furniture Accounting System © 2025",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(130, 480)
            };
            Controls.Add(footerLabel);
        }
        
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                MessageBox.Show("Please enter username!", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernameTextBox.Focus();
                return;
            }
            
            // For demo purposes, accept any password
            Username = usernameTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}