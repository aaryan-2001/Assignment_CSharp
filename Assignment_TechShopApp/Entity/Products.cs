using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Entity
{

    public class Products
    {
        // Private attributes
        private int productID;
        private string productName;
        private string description;
        private decimal price;
        private int categoryId;

        // Public properties with data validation
        public int ProductID { get { return productID; } set { productID = value; } }

        public string ProductName { get { return productName; } set { productName = value; } }

        public string Description { get { return description; } set { description = value; } }

        public decimal Price { get { return price; } set { price = value; } }

        public int CategoryID { get { return categoryId; } set { categoryId = value; } }
    
            // Constructor

         public Products() { }
        public Products(int productID, string productName, string description, decimal price)
        {
            ProductID = productID;
            ProductName = productName;
            Description = description;
            Price = price;
        }

        // Override ToString method
        public override string ToString()
        {
            return $"ProductID: {ProductID}, ProductName: {ProductName},Description: {Description}, Price: {Price}";
        }


    }
}