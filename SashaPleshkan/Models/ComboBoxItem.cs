namespace FurnitureAccounting.Models
{
    public class ComboBoxItem
    {
        public int Id { get; set; }
        public string DisplayText { get; set; }
        public int? DepartmentId { get; set; }
        
        public override string ToString()
        {
            return DisplayText;
        }
    }
}