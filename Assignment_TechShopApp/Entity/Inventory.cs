using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Entity
{
    public class Inventory
    {
        // Attributes
        private int inventoryID;
        private Products product; // Composition relationship with Products class

        private int quantityInStock;
        private DateTime lastStockUpdate;

        // Properties with encapsulation 
        public int InventoryID{get { return inventoryID; }set { inventoryID = value; }}

        public Products Product{get { return product; }set { product = value; }}

        public int QuantityInStock{get { return quantityInStock; }
            set
            {
                if (value >= 0)
                {
                    quantityInStock = value;
                }
                else
                {
                    throw new ArgumentException("Quantity in stock must be non-negative.");
                }
            }
        }

        public DateTime LastStockUpdate{get { return lastStockUpdate; }set { lastStockUpdate = value; }}

        public override string ToString()
        {
            return $"Inventory ID: {InventoryID}\nProduct: {Product.ProductName}\nQuantity in Stock: {QuantityInStock}\nLast Stock Update: {LastStockUpdate}";

        }

    }
}
