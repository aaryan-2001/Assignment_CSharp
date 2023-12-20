using Assignment_TechShopApp.Entity;
using Assignment_TechShopApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICustomerInterface customerobj = new CustomerRepository();
            IProductInterface productobj = new ProductRepository();
            IOrderInterface orderobj = new OrderRepository();
            IOrderDetailsInterface orderDetailobj = new OrderDetailRepository();

            IInventoryInterface inventoryobj = new IInventoryRepository();


            Console.WriteLine(customerobj.CalculateTotalOrders(1));


            Console.WriteLine(customerobj.GetCustomerinfo(3));


            int customerId = 12;
            string newEmail = "newemail@example.com";
            string newPhone = "123-456-7890";
            string newAddress = "123 Main St, City, Country";

            customerobj.UpdateCustomerInfo(customerId, newEmail, newPhone, newAddress);

            int productId = 25;
            decimal price = 100;
            string description = "New updated product";

            productobj.UpdateProductInfo(productId, price, description);


            Console.WriteLine(productobj.GetProductDetails(10));

            bool isInStock = productobj.IsProductInStock(productId);

            if (isInStock)
            {
                Console.WriteLine("Product is in stock.");
            }
            else
            {
                Console.WriteLine("Product is out of stock.");
            }

            int loggedInCustomerId = 1;
            decimal totalAmount = orderobj.CalculateTotalAmount(loggedInCustomerId);
            Console.WriteLine(totalAmount);

            List<Orders> allOrders = orderobj.GetAllOrders();
            foreach (var order in allOrders)
            {
               
                Console.WriteLine($"Order ID: {order.OrderID}, Date: {order.OrderDate}, Total Amount: {order.TotalAmount:C}");

            }
            int customerId = 7;

            Console.WriteLine(orderobj.GetAllOrders(customerId));

            Console.Write("Enter the Order ID: ");
            string orderId = Console.ReadLine();

            Console.Write("Enter the new status: ");
            string newStatus = Console.ReadLine();

            string result = orderobj.UpdateOrderStatus(orderId, newStatus);
            Console.WriteLine(result);

            Console.Write("Enter the Order ID to cancel: ");
            string orderId = Console.ReadLine();

            int result = orderobj.CancelOrder(orderId);
            Console.WriteLine(result == 1 ? "Order canceled successfully." : "Order not found or cancellation failed.");

            Console.Write("Enter the OrderDetail ID: ");
            int orderDetailId;

            while (!int.TryParse(Console.ReadLine(), out orderDetailId))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for OrderDetail ID.");
                Console.Write("Enter the OrderDetail ID: ");
            }

            decimal subtotal = orderDetailobj.CalculateSubtotal(orderDetailId);
            Console.WriteLine($"Subtotal: {subtotal}");


            Console.Write("Enter the OrderDetail ID to update: ");
            int orderDetailId;

            while (!int.TryParse(Console.ReadLine(), out orderDetailId))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for OrderDetail ID.");
                Console.Write("Enter the OrderDetail ID: ");
            }

            Console.Write("Enter the new quantity: ");
            int newQuantity;

            while (!int.TryParse(Console.ReadLine(), out newQuantity))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for new quantity.");
                Console.Write("Enter the new quantity: ");
            }

            int rowsAffected = orderDetailobj.UpdateQuantity(orderDetailId, newQuantity);

            if (rowsAffected > 0)
            {
                Console.WriteLine($"Quantity updated successfully");
            }
            else
            {
                Console.WriteLine("Failed to update quantity.");
            }



            Console.Write("Enter the OrderDetail ID to apply discount: ");
            int orderDetailId;

            while (!int.TryParse(Console.ReadLine(), out orderDetailId))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for OrderDetail ID.");
                Console.Write("Enter the OrderDetail ID: ");
            }

            Console.Write("Enter the discount percentage: ");
            int discountPercentage;

            while (!int.TryParse(Console.ReadLine(), out discountPercentage))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for discount percentage.");
                Console.Write("Enter the discount percentage: ");
            }

            orderDetailobj.AddDiscount(orderDetailId, discountPercentage);
        



        Console.ReadLine();
        }
    }
}
