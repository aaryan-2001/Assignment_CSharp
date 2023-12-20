using Assignment_TechShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Repository
{
    public interface ICustomerInterface
    {
        Customers GetCustomerinfo(int customerId);
        void UpdateCustomerInfo(int customerId, string email, string phone, string address);
        int CalculateTotalOrders(int customerId);
    }

}
