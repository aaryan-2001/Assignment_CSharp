using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Entity
{
    public class OrderDetails
    {
        // Attributes
        private int orderDetailID;
        private Orders order;                           // Composition relationship with Orders class
        private Products product;                       // Composition relationship with Products class
        private int quantity;

        // Properties with encapsulation 
        public int OrderDetailID { get { return orderDetailID; } set { orderDetailID = value; } }

        public Orders Order { get { return order; } set { order = value; } }                 // Composition relationship with Orders class

        public Products Product { get { return product; } set { product = value; } }          // Composition relationship with Products class

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value > 0)
                {
                    quantity = value;
                }
                else
                {
                    throw new ArgumentException("Quantity must be a positive integer.");
                }
            }
        }

    }     
}
