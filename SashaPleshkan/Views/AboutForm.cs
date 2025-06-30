using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FurnitureAccounting.Views
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            LoadAboutInfo();
        }

        private void LoadAboutInfo()
        {
            versionLabel.Text = $"Версия: {GetAssemblyVersion()}";
            authorLabel.Text = "Автор: Плешкан Александр";
            copyrightLabel.Text = $"© {DateTime.Now.Year} Все права защищены";
        }

        private string GetAssemblyVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return $"{version.Major}.{version.Minor}.{version.Build}";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void helpLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Система учета мебели - это приложение для управления и отслеживания мебели в организации.\n\n" +
                "Основные функции:\n" +
                "• Учет мебели с инвентарными номерами\n" +
                "• Управление отделами и назначениями\n" +
                "• Списание устаревшей мебели\n" +
                "• Формирование отчетов\n" +
                "• Ведение журнала действий\n" +
                "• Импорт и экспорт данных\n\n" +
                "Для получения подробной справки обратитесь к руководству пользователя.",
                "Справка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}