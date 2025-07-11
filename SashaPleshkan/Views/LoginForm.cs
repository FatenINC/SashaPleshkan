using System;
using System.Drawing;
using System.Windows.Forms;

namespace FurnitureAccounting.Views
{
    public partial class LoginForm : Form
    {
        public string Username { get; private set; } = string.Empty;

        public LoginForm()
        {
            InitializeComponent();
            SetupEventHandlers();
            usernameTextBox.Text = Environment.UserName;
        }

        private void SetupEventHandlers()
        {
            mainPanel.Paint += (s, e) =>
            {
                var rect = new Rectangle(5, 5, mainPanel.Width - 5, mainPanel.Height - 5);
                using (var brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
            };

            passwordTextBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    LoginButton_Click(s, e);
            };

            loginButton.Click += LoginButton_Click;
            loginButton.MouseEnter += (s, e) => loginButton.BackColor = Color.FromArgb(41, 128, 185);
            loginButton.MouseLeave += (s, e) => loginButton.BackColor = Color.FromArgb(52, 152, 219);
        }

        private void LoginButton_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernameTextBox.Focus();
                return;
            }

            Username = usernameTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void footerLabel_Click(object sender, EventArgs e)
        {

        }
    }
}