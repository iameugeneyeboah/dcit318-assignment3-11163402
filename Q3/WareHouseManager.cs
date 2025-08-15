using System;

namespace Assignment3.Q3
{
    public class WareHouseManager
    {
        private readonly InventoryRepository<ElectronicItem> _electronics = new();
        private readonly InventoryRepository<GroceryItem> _groceries = new();

        public void SeedData()
        {
            _electronics.AddItem(new ElectronicItem(1, "Laptop", 10, "Dell", 24));
            _electronics.AddItem(new ElectronicItem(2, "Phone", 25, "Samsung", 12));
            _electronics.AddItem(new ElectronicItem(3, "Headphones", 40, "Sony", 18));

            _groceries.AddItem(new GroceryItem(101, "Rice", 100, DateTime.Today.AddMonths(12)));
            _groceries.AddItem(new GroceryItem(102, "Milk", 50, DateTime.Today.AddDays(10)));
            _groceries.AddItem(new GroceryItem(103, "Eggs", 200, DateTime.Today.AddDays(14)));
        }

        public void PrintAllItems<T>(InventoryRepository<T> repo) where T : IInventoryItem
        {
            foreach (var item in repo.GetAllItems())
                Console.WriteLine(item);
        }

        public void IncreaseStock<T>(InventoryRepository<T> repo, int id, int quantity) where T : IInventoryItem
        {
            try
            {
                var item = repo.GetItemById(id);
                repo.UpdateQuantity(id, item.Quantity + quantity);
                Console.WriteLine($"Stock increased for Id={id}. New Qty={item.Quantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error increasing stock: {ex.Message}");
            }
        }

        public void RemoveItemById<T>(InventoryRepository<T> repo, int id) where T : IInventoryItem
        {
            try
            {
                repo.RemoveItem(id);
                Console.WriteLine($"Removed item Id={id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing item: {ex.Message}");
            }
        }

        public void Run()
        {
            Console.WriteLine("===== QUESTION 3: Warehouse Inventory (Collections + Generics + Exceptions) =====\n");
            SeedData();

            Console.WriteLine("Grocery Items:");
            PrintAllItems(_groceries);
            Console.WriteLine();

            Console.WriteLine("Electronic Items:");
            PrintAllItems(_electronics);
            Console.WriteLine();

            try
            {
                Console.WriteLine("-- Attempting to add duplicate electronic item with Id=1");
                _electronics.AddItem(new ElectronicItem(1, "Tablet", 5, "Apple", 12));
            }
            catch (Exception ex) { Console.WriteLine($"Caught: {ex.Message}"); }

            Console.WriteLine("-- Attempting to remove non-existent grocery item Id=999");
            RemoveItemById(_groceries, 999);

            Console.WriteLine("-- Attempting to update with invalid quantity (-10) for electronic Id=2");
            try { _electronics.UpdateQuantity(2, -10); }
            catch (Exception ex) { Console.WriteLine($"Caught: {ex.Message}"); }

            Console.WriteLine();
        }
    }
}
