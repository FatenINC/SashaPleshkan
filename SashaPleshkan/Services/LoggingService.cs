using FurnitureAccounting.Models;

namespace FurnitureAccounting.Services
{
    public class LoggingService
    {
        private readonly DataService _dataService;
        
        public LoggingService(DataService dataService)
        {
            _dataService = dataService;
        }
        
        public void LogAction(string action, string details)
        {
            var log = new ActionLog
            {
                Action = action,
                Details = details
            };
            
            _dataService.AddLog(log);
        }
    }
}