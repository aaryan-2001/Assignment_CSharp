using Assignment_TechShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Repository
{
    public interface IOrderInterface
    {
        decimal CalculateTotalAmount(int customerID);
        Orders GetAllOrders(int customerID);
        
        string UpdateOrderStatus(string orderId, string newStatus);
        int CancelOrder(string orderId);
    }

}
