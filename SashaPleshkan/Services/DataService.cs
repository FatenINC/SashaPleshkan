using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using FurnitureAccounting.Models;

namespace FurnitureAccounting.Services
{
    public class DataService
    {
        private readonly string _dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        private readonly string _departmentsFile;
        private readonly string _furnitureFile;
        private readonly string _logsFile;
        
        private List<Department> _departments;
        private List<Furniture> _furniture;
        private List<ActionLog> _logs;
        private readonly LoggingService _loggingService;
        
        public DataService()
        {
            Directory.CreateDirectory(_dataPath);
            _departmentsFile = Path.Combine(_dataPath, "departments.json");
            _furnitureFile = Path.Combine(_dataPath, "furniture.json");
            _logsFile = Path.Combine(_dataPath, "logs.json");
            
            _loggingService = new LoggingService(this);
            LoadData();
        }
        
        private void LoadData()
        {
            _departments = LoadFromFile<List<Department>>(_departmentsFile) ?? new List<Department>();
            _furniture = LoadFromFile<List<Furniture>>(_furnitureFile) ?? new List<Furniture>();
            _logs = LoadFromFile<List<ActionLog>>(_logsFile) ?? new List<ActionLog>();
        }
        
        private T LoadFromFile<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return default(T);
                
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default(T);
            }
        }
        
        private void SaveToFile<T>(string filePath, T data)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        
        public List<Department> GetDepartments() => _departments.ToList();
        
        public Department GetDepartment(int id) => _departments.FirstOrDefault(d => d.Id == id);
        
        public void AddDepartment(Department department)
        {
            department.Id = _departments.Any() ? _departments.Max(d => d.Id) + 1 : 1;
            _departments.Add(department);
            SaveToFile(_departmentsFile, _departments);
            _loggingService.LogAction("Добавить отдел", $"Added department: {department.Name}");
        }
        
        public void UpdateDepartment(Department department)
        {
            var index = _departments.FindIndex(d => d.Id == department.Id);
            if (index >= 0)
            {
                _departments[index] = department;
                SaveToFile(_departmentsFile, _departments);
                _loggingService.LogAction("Обновить отдел", $"Updated department: {department.Name}");
            }
        }
        
        public void DeleteDepartment(int id)
        {
            var department = _departments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                _departments.Remove(department);
                SaveToFile(_departmentsFile, _departments);
                _loggingService.LogAction("Удалить отдел", $"Deleted department: {department.Name}");
            }
        }
        
        public List<Furniture> GetFurniture() => _furniture.ToList();
        
        public List<Furniture> GetFurnitureByDepartment(int departmentId) => 
            _furniture.Where(f => f.DepartmentId == departmentId && !f.IsWrittenOff).ToList();
        
        public Furniture GetFurnitureItem(int id) => _furniture.FirstOrDefault(f => f.Id == id);
        
        public void AddFurniture(Furniture furniture)
        {
            furniture.Id = _furniture.Any() ? _furniture.Max(f => f.Id) + 1 : 1;
            _furniture.Add(furniture);
            SaveToFile(_furnitureFile, _furniture);
            _loggingService.LogAction("Добавить мебель", $"Added furniture: {furniture.Name} ({furniture.InventoryNumber})");
        }
        
        public void UpdateFurniture(Furniture furniture)
        {
            var index = _furniture.FindIndex(f => f.Id == furniture.Id);
            if (index >= 0)
            {
                _furniture[index] = furniture;
                SaveToFile(_furnitureFile, _furniture);
                _loggingService.LogAction("Обновить мебель", $"Updated furniture: {furniture.Name} ({furniture.InventoryNumber})");
            }
        }
        
        public void DeleteFurniture(int id)
        {
            var furniture = _furniture.FirstOrDefault(f => f.Id == id);
            if (furniture != null)
            {
                _furniture.Remove(furniture);
                SaveToFile(_furnitureFile, _furniture);
                _loggingService.LogAction("Удалить мебель", $"Deleted furniture: {furniture.Name} ({furniture.InventoryNumber})");
            }
        }
        
        public void AssignFurnitureToDepartment(int furnitureId, int departmentId)
        {
            var furniture = GetFurnitureItem(furnitureId);
            var department = GetDepartment(departmentId);
            
            if (furniture != null && department != null)
            {
                furniture.DepartmentId = departmentId;
                UpdateFurniture(furniture);
                _loggingService.LogAction("Назначить мебель", 
                    $"Assigned {furniture.Name} to {department.Name}");
            }
        }
        
        public void WriteOffFurniture(int furnitureId, string reason)
        {
            var furniture = GetFurnitureItem(furnitureId);
            if (furniture != null && !furniture.IsWrittenOff)
            {
                furniture.IsWrittenOff = true;
                furniture.WriteOffDate = DateTime.Now;
                furniture.WriteOffReason = reason;
                UpdateFurniture(furniture);
                _loggingService.LogAction("Списать мебель", 
                    $"Written off: {furniture.Name} ({furniture.InventoryNumber}). Reason: {reason}");
            }
        }
        
        public List<ActionLog> GetLogs() => _logs.ToList();
        
        public void AddLog(ActionLog log)
        {
            log.Id = _logs.Any() ? _logs.Max(l => l.Id) + 1 : 1;
            _logs.Add(log);
            SaveToFile(_logsFile, _logs);
        }
        
        public void ExportData(string filePath)
        {
            var data = new
            {
                Departments = _departments,
                Furniture = _furniture,
                Logs = _logs,
                ExportDate = DateTime.Now
            };
            
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
            _loggingService.LogAction("Экспорт данных", $"Exported data to: {filePath}");
        }
        
        public void ImportData(string filePath)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                
                _departments = JsonConvert.DeserializeObject<List<Department>>(data.Departments.ToString());
                _furniture = JsonConvert.DeserializeObject<List<Furniture>>(data.Furniture.ToString());
                
                SaveToFile(_departmentsFile, _departments);
                SaveToFile(_furnitureFile, _furniture);
                
                _loggingService.LogAction("Импорт данных", $"Imported data from: {filePath}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to import data: {ex.Message}");
            }
        }
    }
}