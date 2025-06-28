using System;

namespace FurnitureAccounting.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public Department()
        {
            CreatedDate = DateTime.Now;
        }
    }
}