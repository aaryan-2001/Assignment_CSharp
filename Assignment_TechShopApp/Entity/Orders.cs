using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Entity
{
    public class Orders
    {
        
        // Private attributes
        private int orderID;
        private Customers customer; // Composition relationship with Customers class
        private DateTime orderDate;
        private decimal totalAmount;

        // Public properties 

        public List<Products> Products { get; internal set; }
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        public int OrderID{get { return orderID; }set { orderID = value; }}                                                                                            

        public Customers Customer{get { return customer; }set { customer = value; } } // Composition relationship with Customers class

        public DateTime OrderDate{get { return orderDate; }set { orderDate = value; }}

        public decimal TotalAmount{get { return totalAmount; }set{
                if (value >= 0)
                    totalAmount = value;
                else
                    throw new ArgumentException("Total amount cannot be negative.");
            }
        }

       public Orders() { }
        // Constructor
        public Orders(int orderID, Customers customer, DateTime orderDate, decimal totalAmount)
        {
            OrderID = orderID;
            Customer = customer;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
        }

        public override string ToString()
        {
            return $"OrderID: {OrderID}, Customer: {Customer}, OrderDate: {OrderDate}, TotalAmount: {TotalAmount}";
        }
    }

}
