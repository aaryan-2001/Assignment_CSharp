using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Exceptions
{
    internal class InsufficientStockException : Exception
    {
        public InsufficientStockException(string errorMessage) : base(errorMessage)
        { }

        public InsufficientStockException(string itemName, int requestedQuantity, int availableQuantity)
            : base($"Insufficient stock for {itemName}. Requested: {requestedQuantity}, Available: {availableQuantity}")
        { }
    }
}
