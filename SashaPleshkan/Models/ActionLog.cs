using System;

namespace FurnitureAccounting.Models
{
    public class ActionLog
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public string Details { get; set; }
        public DateTime Timestamp { get; set; }
        
        public ActionLog()
        {
            Timestamp = DateTime.Now;
            Username = Environment.UserName;
        }
    }
}