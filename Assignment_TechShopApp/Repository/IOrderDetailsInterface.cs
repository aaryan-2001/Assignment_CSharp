using Assignment_TechShopApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Repository
{
    public interface IOrderDetailsInterface
    {

        
        int CalculateSubtotal(int orderDetailId);


        //OrderDetails GetOrderDetailInfo();
        int UpdateQuantity(int orderDetailId, int newQuantity);
        int AddDiscount(int orderDetailId, int discountPercentage);

    }
}
