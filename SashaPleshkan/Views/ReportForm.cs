using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public partial class ReportForm : Form
    {
        private DataService _dataService;
        private string currentReport;
        
        public ReportForm(DataService dataService)
        {
            _dataService = dataService;
            InitializeComponent();
            SetupEventHandlers();
        }
        
        private void SetupEventHandlers()
        {
            generateButton.Click += GenerateButton_Click;
            saveButton.Click += SaveButton_Click;
            printButton.Click += PrintButton_Click;
            printDocument.PrintPage += PrintDocument_PrintPage;
            
            reportTypeComboBox.Items.AddRange(new[] 
            { 
                "Мебель по отделам",
                "Вся мебель",
                "Списанная мебель",
                "Нераспределенная мебель",
                "Сводка по отделам",
                "Отчет об общей стоимости"
            });
            reportTypeComboBox.SelectedIndex = 0;
            
            saveButton.Enabled = false;
            printButton.Enabled = false;
        }
        
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            currentReport = GenerateReport();
            reportRichTextBox.Text = currentReport;
            saveButton.Enabled = true;
            printButton.Enabled = true;
        }
        
        private string GenerateReport()
        {
            var sb = new StringBuilder();
            var reportType = reportTypeComboBox.Text;
            
            sb.AppendLine("СИСТЕМА УЧЕТА МЕБЕЛИ");
            sb.AppendLine($"Отчет: {reportType}");
            sb.AppendLine($"Создан: {DateTime.Now:F}");
            sb.AppendLine($"Пользователь: {Environment.UserName}");
            sb.AppendLine(new string('=', 80));
            sb.AppendLine();
            
            switch (reportType)
            {
                case "Мебель по отделам":
                    GenerateFurnitureByDepartmentReport(sb);
                    break;
                case "Вся мебель":
                    GenerateAllFurnitureReport(sb);
                    break;
                case "Списанная мебель":
                    GenerateWrittenOffReport(sb);
                    break;
                case "Нераспределенная мебель":
                    GenerateUnassignedReport(sb);
                    break;
                case "Сводка по отделам":
                    GenerateDepartmentSummaryReport(sb);
                    break;
                case "Отчет об общей стоимости":
                    GenerateTotalValueReport(sb);
                    break;
            }
            
            return sb.ToString();
        }
        
        private void GenerateFurnitureByDepartmentReport(StringBuilder sb)
        {
            var departments = _dataService.GetDepartments().OrderBy(d => d.Name);
            
            foreach (var dept in departments)
            {
                var furniture = _dataService.GetFurnitureByDepartment(dept.Id);
                
                sb.AppendLine($"Отдел: {dept.Name}");
                sb.AppendLine($"Описание: {dept.Description ?? "Н/Д"}");
                sb.AppendLine($"Всего предметов: {furniture.Count}");
                sb.AppendLine($"Общая стоимость: ${furniture.Sum(f => f.Price):N2}");
                sb.AppendLine();
                
                if (furniture.Any())
                {
                    sb.AppendLine("  Инвентарный №  | Название                     | Тип       | Цена");
                    sb.AppendLine("  " + new string('-', 70));
                    
                    foreach (var item in furniture.OrderBy(f => f.Name))
                    {
                        sb.AppendLine($"  {item.InventoryNumber,-15} | {item.Name,-28} | {item.Type,-9} | ${item.Price,8:N2}");
                    }
                }
                else
                {
                    sb.AppendLine("  В этом отделе нет мебели.");
                }
                
                sb.AppendLine();
                sb.AppendLine(new string('-', 80));
                sb.AppendLine();
            }
        }
        
        private void GenerateAllFurnitureReport(StringBuilder sb)
        {
            var furniture = _dataService.GetFurniture().Where(f => !f.IsWrittenOff).OrderBy(f => f.Name);
            
            sb.AppendLine($"Всего активной мебели: {furniture.Count()}");
            sb.AppendLine($"Общая стоимость: ${furniture.Sum(f => f.Price):N2}");
            sb.AppendLine();
            
            sb.AppendLine("Инвентарный №  | Название                     | Тип       | Отдел               | Цена");
            sb.AppendLine(new string('-', 90));
            
            foreach (var item in furniture)
            {
                var deptName = item.DepartmentId.HasValue 
                    ? _dataService.GetDepartment(item.DepartmentId.Value)?.Name ?? "Н/Д"
                    : "Не назначен";
                    
                sb.AppendLine($"{item.InventoryNumber,-15} | {item.Name,-28} | {item.Type,-9} | {deptName,-18} | ${item.Price,8:N2}");
            }
        }
        
        private void GenerateWrittenOffReport(StringBuilder sb)
        {
            var furniture = _dataService.GetFurniture().Where(f => f.IsWrittenOff).OrderBy(f => f.WriteOffDate);
            
            sb.AppendLine($"Всего списанных предметов: {furniture.Count()}");
            sb.AppendLine($"Общая стоимость списанных: ${furniture.Sum(f => f.Price):N2}");
            sb.AppendLine();
            
            if (furniture.Any())
            {
                sb.AppendLine("Инвентарный №  | Название                | Дата списания  | Причина");
                sb.AppendLine(new string('-', 80));
                
                foreach (var item in furniture)
                {
                    sb.AppendLine($"{item.InventoryNumber,-15} | {item.Name,-23} | {item.WriteOffDate?.ToString("yyyy-MM-dd") ?? "Н/Д",-14} | {item.WriteOffReason}");
                }
            }
            else
            {
                sb.AppendLine("Списанная мебель не найдена.");
            }
        }
        
        private void GenerateUnassignedReport(StringBuilder sb)
        {
            var furniture = _dataService.GetFurniture()
                .Where(f => !f.IsWrittenOff && !f.DepartmentId.HasValue)
                .OrderBy(f => f.Name);
            
            sb.AppendLine($"Всего нераспределенных предметов: {furniture.Count()}");
            sb.AppendLine($"Общая стоимость нераспределенных: ${furniture.Sum(f => f.Price):N2}");
            sb.AppendLine();
            
            if (furniture.Any())
            {
                sb.AppendLine("Инвентарный №  | Название                     | Тип       | Дата покупки  | Цена");
                sb.AppendLine(new string('-', 85));
                
                foreach (var item in furniture)
                {
                    sb.AppendLine($"{item.InventoryNumber,-15} | {item.Name,-28} | {item.Type,-9} | {item.PurchaseDate:yyyy-MM-dd}    | ${item.Price,8:N2}");
                }
            }
            else
            {
                sb.AppendLine("Вся мебель распределена по отделам.");
            }
        }
        
        private void GenerateDepartmentSummaryReport(StringBuilder sb)
        {
            var departments = _dataService.GetDepartments().OrderBy(d => d.Name);
            
            sb.AppendLine("Название отдела              | Предм.| Активная стоим.| Списано");
            sb.AppendLine(new string('-', 70));
            
            decimal totalActiveValue = 0;
            decimal totalWrittenOffValue = 0;
            int totalItems = 0;
            
            foreach (var dept in departments)
            {
                var allFurniture = _dataService.GetFurniture().Where(f => f.DepartmentId == dept.Id);
                var activeFurniture = allFurniture.Where(f => !f.IsWrittenOff);
                var writtenOffFurniture = allFurniture.Where(f => f.IsWrittenOff);
                
                var activeValue = activeFurniture.Sum(f => f.Price);
                var writtenOffValue = writtenOffFurniture.Sum(f => f.Price);
                
                sb.AppendLine($"{dept.Name,-28} | {activeFurniture.Count(),5} | ${activeValue,12:N2} | ${writtenOffValue,10:N2}");
                
                totalActiveValue += activeValue;
                totalWrittenOffValue += writtenOffValue;
                totalItems += activeFurniture.Count();
            }
            
            sb.AppendLine(new string('-', 70));
            sb.AppendLine($"{"ИТОГО",-28} | {totalItems,5} | ${totalActiveValue,12:N2} | ${totalWrittenOffValue,10:N2}");
        }
        
        private void GenerateTotalValueReport(StringBuilder sb)
        {
            var allFurniture = _dataService.GetFurniture();
            var activeFurniture = allFurniture.Where(f => !f.IsWrittenOff);
            var writtenOffFurniture = allFurniture.Where(f => f.IsWrittenOff);
            
            sb.AppendLine("СВОДКА ПО ОБЩЕЙ СТОИМОСТИ");
            sb.AppendLine(new string('-', 40));
            sb.AppendLine($"Активная мебель:            {activeFurniture.Count(),6}");
            sb.AppendLine($"Стоимость активной мебели:  ${activeFurniture.Sum(f => f.Price),12:N2}");
            sb.AppendLine();
            sb.AppendLine($"Списанные предметы:         {writtenOffFurniture.Count(),6}");
            sb.AppendLine($"Стоимость списанных:        ${writtenOffFurniture.Sum(f => f.Price),12:N2}");
            sb.AppendLine();
            sb.AppendLine($"Всего предметов:            {allFurniture.Count(),6}");
            sb.AppendLine($"Общая первоначальная стоим.:${allFurniture.Sum(f => f.Price),12:N2}");
            sb.AppendLine();
            
            sb.AppendLine("СТОИМОСТЬ ПО ТИПАМ");
            sb.AppendLine(new string('-', 40));
            
            var byType = activeFurniture.GroupBy(f => f.Type)
                .OrderByDescending(g => g.Sum(f => f.Price));
                
            foreach (var group in byType)
            {
                sb.AppendLine($"{group.Key,-20} {group.Count(),5} предм.  ${group.Sum(f => f.Price),12:N2}");
            }
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                dialog.Title = "Сохранить отчет";
                dialog.FileName = $"{reportTypeComboBox.Text.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllText(dialog.FileName, currentReport);
                        MessageBox.Show("Отчет успешно сохранен!", "Успех", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void PrintButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new PrintDialog())
            {
                dialog.Document = printDocument;
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        printDocument.Print();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка печати: {ex.Message}", "Ошибка", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var font = new Font("Courier New", 10);
            var brush = Brushes.Black;
            var leftMargin = e.MarginBounds.Left;
            var topMargin = e.MarginBounds.Top;
            var linesPerPage = e.MarginBounds.Height / font.GetHeight(e.Graphics);
            
            var lines = currentReport.Split('\n');
            var linesPrinted = 0;
            
            foreach (var line in lines)
            {
                if (linesPrinted >= linesPerPage)
                {
                    e.HasMorePages = true;
                    return;
                }
                
                e.Graphics.DrawString(line, font, brush, leftMargin, topMargin + (linesPrinted * font.GetHeight(e.Graphics)));
                linesPrinted++;
            }
            
            e.HasMorePages = false;
        }
    }
}