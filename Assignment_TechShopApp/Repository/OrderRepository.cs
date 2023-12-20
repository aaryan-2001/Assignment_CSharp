using Assignment_TechShopApp.Entity;
using System;
using Assignment_TechShopApp.Utility;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace Assignment_TechShopApp.Repository
{
    public class OrderRepository : IOrderInterface
    {

        public List<Orders> order = new List<Orders>();
        public List<Products> Products { get; set; } = new List<Products>(); // Ensure it's List<Products>

        //public List<Customers> customer = new List<Customers>();

        public string connectionString;
        SqlCommand command = null;

        public OrderRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            command = new SqlCommand();
        }

        public decimal CalculateTotalAmount(int customerID)
        {
            string query = "SELECT SUM(Products.Price * OrderDetail.Quantity) AS TotalAmount " +
                           "FROM Orders " +
                           "INNER JOIN OrderDetail ON Orders.OrderID = OrderDetail.OrderID " +
                           "INNER JOIN Products ON OrderDetail.ProductID = Products.ProductID " +
                           "WHERE Orders.CustomerID = @CustomerId";

            decimal totalAmount = 0;

            try
            {
                using (SqlConnection SqlConnection = new SqlConnection(connectionString))
                {
                    SqlConnection.Open();

                    using (SqlCommand command = new SqlCommand(query, SqlConnection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Assuming the result is a decimal value in the database
                                totalAmount = Convert.ToDecimal(reader["TotalAmount"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calculating total amount: {ex.Message}");
            }

            return totalAmount;
        }

        public Orders GetAllOrders(int customerID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string query = "SELECT * FROM Orders WHERE CustomerID = @CustomerId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to the SQL query to avoid SQL injection
                        command.Parameters.AddWithValue("@CustomerId", customerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int orderId = (int)reader["OrderID"];
                                DateTime orderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
                                string status = reader["Status"].ToString();
                       
                                Console.WriteLine($"Order ID: {orderId}");
                                Console.WriteLine($"orderDate: {orderDate}");
                                Console.WriteLine($"Status: {status}");

                            }
                            return null;
                        }

                    }
                    
                }
                
            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public string UpdateOrderStatus(string orderId, string newStatus)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Replace "Orders" with the actual name of your orders table
                    string updateQuery = "UPDATE Orders SET Status = @NewStatus WHERE OrderID = @OrderID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewStatus", newStatus);
                        command.Parameters.AddWithValue("@OrderID", orderId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return $"Order status updated to: {newStatus}";
                        }
                        else
                        {
                            return $"Order with ID {orderId} not found.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"An error occurred: {ex.Message}";
            }
        }

        public int CancelOrder(string orderId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                  
                    string updateQuery = "UPDATE Orders SET Status = 'Canceled' WHERE OrderID = @OrderID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderId);

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return 0;

            }
        }


    }
}