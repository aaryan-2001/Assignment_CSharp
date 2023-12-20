using Assignment_TechShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Repository
{
    internal interface IInventoryInterface
    { 
    Products GetProduct();
    int GetQuantityInStock();
    int AddToInventory(int quantity);
    int RemoveFromInventory(int quantity);
    int UpdateStockQuantity(int newQuantity);
    bool IsProductAvailable(int quantityToCheck);
    int GetInventoryValue();
    string ListLowStockProducts(int threshold);
    string ListOutOfStockProducts();
    string ListAllProducts();

    }
}
