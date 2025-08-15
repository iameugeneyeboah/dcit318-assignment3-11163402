using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Assignment3.Q5
{
    public interface IInventoryEntity { int Id { get; } }
    public record InventoryItem(int Id, string Name, int Quantity, DateTime DateAdded) : IInventoryEntity;

    public class InventoryLogger<T> where T : IInventoryEntity
    {
        private readonly List<T> _log = new();
        private readonly string _filePath;

        public InventoryLogger(string filePath) { _filePath = filePath; }

        public void Add(T item) => _log.Add(item);
        public List<T> GetAll() => new(_log);

        public void SaveToFile()
        {
            try
            {
                using var fs = new FileStream(_filePath, FileMode.Create, FileAccess.Write, FileShare.None);
                JsonSerializer.Serialize(fs, _log, new JsonSerializerOptions { WriteIndented = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                if (!File.Exists(_filePath)) { Console.WriteLine("No saved file found."); return; }
                using var fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                var data = JsonSerializer.Deserialize<List<T>>(fs) ?? new List<T>();
                _log.Clear();
                _log.AddRange(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
            }
        }
    }

    public class InventoryApp
    {
        private readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "inventory_log.json");
        private InventoryLogger<InventoryItem> _logger;

        public InventoryApp() { _logger = new InventoryLogger<InventoryItem>(_dataPath); }

        public void SeedSampleData()
        {
            _logger.Add(new InventoryItem(1, "Stapler", 15, DateTime.Now));
            _logger.Add(new InventoryItem(2, "A4 Paper Ream", 40, DateTime.Now));
            _logger.Add(new InventoryItem(3, "Markers", 25, DateTime.Now));
            _logger.Add(new InventoryItem(4, "Printer Toner", 6, DateTime.Now));
            _logger.Add(new InventoryItem(5, "Envelopes", 100, DateTime.Now));
        }

        public void SaveData() => _logger.SaveToFile();
        public void LoadData() => _logger.LoadFromFile();

        public void PrintAllItems()
        {
            foreach (var item in _logger.GetAll())
                Console.WriteLine($"InventoryItem {{ Id={item.Id}, Name={item.Name}, Qty={item.Quantity}, DateAdded={item.DateAdded:yyyy-MM-dd HH:mm} }}");
        }

        public void Run()
        {
            Console.WriteLine("===== QUESTION 5: Inventory Records (Records + Generics + File I/O) =====\n");
            SeedSampleData();
            SaveData();
            _logger = new InventoryLogger<InventoryItem>(_dataPath);
            LoadData();
            PrintAllItems();
            Console.WriteLine();
        }
    }
}
