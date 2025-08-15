using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment3.Q3
{
    public interface IInventoryItem
    {
        int Id { get; }
        string Name { get; }
        int Quantity { get; set; }
    }

    public class ElectronicItem : IInventoryItem
    {
        public int Id { get; }
        public string Name { get; }
        public int Quantity { get; set; }
        public string Brand { get; }
        public int WarrantyMonths { get; }

        public ElectronicItem(int id, string name, int quantity, string brand, int warrantyMonths)
        { Id = id; Name = name; Quantity = quantity; Brand = brand; WarrantyMonths = warrantyMonths; }

        public override string ToString() => $"ElectronicItem {{ Id={Id}, Name={Name}, Qty={Quantity}, Brand={Brand}, Warranty={WarrantyMonths}m }}";
    }

    public class GroceryItem : IInventoryItem
    {
        public int Id { get; }
        public string Name { get; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; }

        public GroceryItem(int id, string name, int quantity, DateTime expiryDate)
        { Id = id; Name = name; Quantity = quantity; ExpiryDate = expiryDate; }

        public override string ToString() => $"GroceryItem {{ Id={Id}, Name={Name}, Qty={Quantity}, Expiry={ExpiryDate:yyyy-MM-dd} }}";
    }
}
