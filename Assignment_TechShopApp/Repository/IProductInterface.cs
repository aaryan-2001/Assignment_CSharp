using Assignment_TechShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Repository
{
    public interface IProductInterface
    {
        Products GetProductDetails(int productId);
        void UpdateProductInfo(int productId, decimal price, string description);
        bool IsProductInStock(int productId);

    }
}
