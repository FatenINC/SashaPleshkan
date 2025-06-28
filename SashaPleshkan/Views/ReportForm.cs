using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FurnitureAccounting.Services;

namespace FurnitureAccounting.Views
{
    public class ReportForm : Form
    {
        private DataService _dataService;
        private RichTextBox reportTextBox;
        private ComboBox reportTypeComboBox;
        private Button generateButton;
        private Button saveButton;
        private Button printButton;
        private PrintDocument printDocument;
        private string currentReport;
        
        public ReportForm(DataService dataService)
        {
            _dataService = dataService;
            printDocument = new PrintDocument();
            printDocument.PrintPage += PrintDocument_PrintPage;
            InitializeComponents();
        }
        
        private void InitializeComponents()
        {
            Text = "Generate Reports";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterParent;
            
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                Padding = new Padding(10)
            };
            
            var controlPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Height = 40
            };
            
            controlPanel.Controls.Add(new Label { Text = "Report Type:", AutoSize = true, Anchor = AnchorStyles.Left });
            
            reportTypeComboBox = new ComboBox
            {
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            reportTypeComboBox.Items.AddRange(new[] 
            { 
                "Furniture by Department",
                "All Furniture",
                "Written-off Furniture",
                "Unassigned Furniture",
                "Department Summary",
                "Total Value Report"
            });
            reportTypeComboBox.SelectedIndex = 0;
            controlPanel.Controls.Add(reportTypeComboBox);
            
            generateButton = new Button { Text = "Generate", Width = 100 };
            generateButton.Click += GenerateButton_Click;
            controlPanel.Controls.Add(generateButton);
            
            saveButton = new Button { Text = "Save", Width = 80, Enabled = false };
            saveButton.Click += SaveButton_Click;
            controlPanel.Controls.Add(saveButton);
            
            printButton = new Button { Text = "Print", Width = 80, Enabled = false };
            printButton.Click += PrintButton_Click;
            controlPanel.Controls.Add(printButton);
            
            reportTextBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Font = new Font("Consolas", 10),
                WordWrap = false
            };
            
            mainPanel.Controls.Add(controlPanel, 0, 0);
            mainPanel.Controls.Add(reportTextBox, 0, 1);
            
            Controls.Add(mainPanel);
        }
        
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            currentReport = GenerateReport();
            reportTextBox.Text = currentReport;
            saveButton.Enabled = true;
            printButton.Enabled = true;
        }
        
        private string GenerateReport()
        {
            var sb = new StringBuilder();
            var reportType = reportTypeComboBox.Text;
            
            sb.AppendLine("FURNITURE ACCOUNTING SYSTEM");
            sb.AppendLine($"Report: {reportType}");
            sb.AppendLine($"Generated: {DateTime.Now:F}");
            sb.AppendLine($"User: {Environment.UserName}");
            sb.AppendLine(new string('=', 80));
            sb.AppendLine();
            
            switch (reportType)
            {
                case "Furniture by Department":
                    GenerateFurnitureByDepartmentReport(sb);
                    break;
                case "All Furniture":
                    GenerateAllFurnitureReport(sb);
                    break;
                case "Written-off Furniture":
                    GenerateWrittenOffReport(sb);
                    break;
                case "Unassigned Furniture":
                    GenerateUnassignedReport(sb);
                    break;
                case "Department Summary":
                    GenerateDepartmentSummaryReport(sb);
                    break;
                case "Total Value Report":
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
                
                sb.AppendLine($"Department: {dept.Name}");
                sb.AppendLine($"Description: {dept.Description ?? "N/A"}");
                sb.AppendLine($"Total Items: {furniture.Count}");
                sb.AppendLine($"Total Value: ${furniture.Sum(f => f.Price):N2}");
                sb.AppendLine();
                
                if (furniture.Any())
                {
                    sb.AppendLine("  Inventory#     | Name                         | Type      | Price");
                    sb.AppendLine("  " + new string('-', 70));
                    
                    foreach (var item in furniture.OrderBy(f => f.Name))
                    {
                        sb.AppendLine($"  {item.InventoryNumber,-15} | {item.Name,-28} | {item.Type,-9} | ${item.Price,8:N2}");
                    }
                }
                else
                {
                    sb.AppendLine("  No furniture assigned to this department.");
                }
                
                sb.AppendLine();
                sb.AppendLine(new string('-', 80));
                sb.AppendLine();
            }
        }
        
        private void GenerateAllFurnitureReport(StringBuilder sb)
        {
            var furniture = _dataService.GetFurniture().Where(f => !f.IsWrittenOff).OrderBy(f => f.Name);
            
            sb.AppendLine($"Total Active Furniture Items: {furniture.Count()}");
            sb.AppendLine($"Total Value: ${furniture.Sum(f => f.Price):N2}");
            sb.AppendLine();
            
            sb.AppendLine("Inventory#     | Name                         | Type      | Department          | Price");
            sb.AppendLine(new string('-', 90));
            
            foreach (var item in furniture)
            {
                var deptName = item.DepartmentId.HasValue 
                    ? _dataService.GetDepartment(item.DepartmentId.Value)?.Name ?? "N/A"
                    : "Unassigned";
                    
                sb.AppendLine($"{item.InventoryNumber,-15} | {item.Name,-28} | {item.Type,-9} | {deptName,-18} | ${item.Price,8:N2}");
            }
        }
        
        private void GenerateWrittenOffReport(StringBuilder sb)
        {
            var furniture = _dataService.GetFurniture().Where(f => f.IsWrittenOff).OrderBy(f => f.WriteOffDate);
            
            sb.AppendLine($"Total Written-off Items: {furniture.Count()}");
            sb.AppendLine($"Total Written-off Value: ${furniture.Sum(f => f.Price):N2}");
            sb.AppendLine();
            
            if (furniture.Any())
            {
                sb.AppendLine("Inventory#     | Name                    | Write-off Date | Reason");
                sb.AppendLine(new string('-', 80));
                
                foreach (var item in furniture)
                {
                    sb.AppendLine($"{item.InventoryNumber,-15} | {item.Name,-23} | {item.WriteOffDate?.ToString("yyyy-MM-dd") ?? "N/A",-14} | {item.WriteOffReason}");
                }
            }
            else
            {
                sb.AppendLine("No written-off furniture found.");
            }
        }
        
        private void GenerateUnassignedReport(StringBuilder sb)
        {
            var furniture = _dataService.GetFurniture()
                .Where(f => !f.IsWrittenOff && !f.DepartmentId.HasValue)
                .OrderBy(f => f.Name);
            
            sb.AppendLine($"Total Unassigned Items: {furniture.Count()}");
            sb.AppendLine($"Total Unassigned Value: ${furniture.Sum(f => f.Price):N2}");
            sb.AppendLine();
            
            if (furniture.Any())
            {
                sb.AppendLine("Inventory#     | Name                         | Type      | Purchase Date | Price");
                sb.AppendLine(new string('-', 85));
                
                foreach (var item in furniture)
                {
                    sb.AppendLine($"{item.InventoryNumber,-15} | {item.Name,-28} | {item.Type,-9} | {item.PurchaseDate:yyyy-MM-dd}    | ${item.Price,8:N2}");
                }
            }
            else
            {
                sb.AppendLine("All furniture items are assigned to departments.");
            }
        }
        
        private void GenerateDepartmentSummaryReport(StringBuilder sb)
        {
            var departments = _dataService.GetDepartments().OrderBy(d => d.Name);
            
            sb.AppendLine("Department Name              | Items | Active Value  | Written-off");
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
            sb.AppendLine($"{"TOTAL",-28} | {totalItems,5} | ${totalActiveValue,12:N2} | ${totalWrittenOffValue,10:N2}");
        }
        
        private void GenerateTotalValueReport(StringBuilder sb)
        {
            var allFurniture = _dataService.GetFurniture();
            var activeFurniture = allFurniture.Where(f => !f.IsWrittenOff);
            var writtenOffFurniture = allFurniture.Where(f => f.IsWrittenOff);
            
            sb.AppendLine("TOTAL VALUE SUMMARY");
            sb.AppendLine(new string('-', 40));
            sb.AppendLine($"Active Furniture Items:     {activeFurniture.Count(),6}");
            sb.AppendLine($"Active Furniture Value:     ${activeFurniture.Sum(f => f.Price),12:N2}");
            sb.AppendLine();
            sb.AppendLine($"Written-off Items:          {writtenOffFurniture.Count(),6}");
            sb.AppendLine($"Written-off Value:          ${writtenOffFurniture.Sum(f => f.Price),12:N2}");
            sb.AppendLine();
            sb.AppendLine($"Total Items:                {allFurniture.Count(),6}");
            sb.AppendLine($"Total Original Value:       ${allFurniture.Sum(f => f.Price),12:N2}");
            sb.AppendLine();
            
            sb.AppendLine("VALUE BY TYPE");
            sb.AppendLine(new string('-', 40));
            
            var byType = activeFurniture.GroupBy(f => f.Type)
                .OrderByDescending(g => g.Sum(f => f.Price));
                
            foreach (var group in byType)
            {
                sb.AppendLine($"{group.Key,-20} {group.Count(),5} items   ${group.Sum(f => f.Price),12:N2}");
            }
        }
        
        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                dialog.Title = "Save Report";
                dialog.FileName = $"{reportTypeComboBox.Text.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllText(dialog.FileName, currentReport);
                        MessageBox.Show("Report saved successfully!", "Success", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Save failed: {ex.Message}", "Error", 
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
                        MessageBox.Show($"Print failed: {ex.Message}", "Error", 
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