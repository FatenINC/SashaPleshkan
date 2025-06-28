using System;

namespace FurnitureAccounting.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string InventoryNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? DepartmentId { get; set; }
        public bool IsWrittenOff { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public string WriteOffReason { get; set; }
        
        public Furniture()
        {
            PurchaseDate = DateTime.Now;
            IsWrittenOff = false;
        }
    }
}