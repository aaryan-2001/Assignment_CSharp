using Assignment_TechShopApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Repository
{
    public class OrderDetailRepository : IOrderDetailsInterface
    {
        public string connectionString;
        SqlCommand command = null;
        public OrderDetailRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            command = new SqlCommand();
        }

        public int CalculateSubtotal(int orderDetailId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT OD.Quantity, P.Price " +
                                   "FROM OrderDetail OD " +
                                   "INNER JOIN Products P ON OD.ProductID = P.ProductID " +
                                   "WHERE OD.OrderDetailID = @OrderDetailID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderDetailID", orderDetailId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Read the quantity and unit price from the database
                                int quantity = (int)reader["Quantity"];
                                decimal price = (decimal)reader["Price"];

                                return (int)(quantity * price);
                            }
                            else
                            {
                                Console.WriteLine($"Order detail with ID {orderDetailId} not found.");
                                return 0;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return 0;
            }
        }


        public int UpdateQuantity(int orderDetailId, int newQuantity)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE OrderDetail SET Quantity = @NewQuantity WHERE OrderDetailID = @OrderDetailID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                        command.Parameters.AddWithValue("@OrderDetailID", orderDetailId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return rowsAffected;
                        }
                        else
                        {
                            Console.WriteLine($"Order detail with ID {orderDetailId} not found.");
                            return 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return 0;
            }
        }

        public int AddDiscount(int orderDetailId, int discountPercentage)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Replace "OrderDetail" and "Products" with the actual names of your tables
                    string selectQuery = "SELECT OD.Quantity, P.Price " +
                                         "FROM OrderDetail OD " +
                                         "INNER JOIN Products P ON OD.ProductID = P.ProductID " +
                                         "WHERE OD.OrderDetailID = @OrderDetailID";

                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@OrderDetailID", orderDetailId);

                        using (SqlDataReader reader = selectCommand.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Read the quantity and unit price from the database
                                int quantity = (int)reader["Quantity"];
                                decimal unitPrice = (decimal)reader["Price"];

                                // Calculate total and discounted total
                                decimal total = quantity * unitPrice;
                                decimal discountAmount = (discountPercentage / 100.0m) * total;
                                decimal discountedTotal = total - discountAmount;

                                // Display the results or perform further actions as needed
                                Console.WriteLine($"Total: {total}");
                                Console.WriteLine($"Discounted Total: {discountedTotal}");
                            }
                            else
                            {
                                Console.WriteLine($"Order detail with ID {orderDetailId} not found.");
                            }
                            
                        }
                        
                    }
                    
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
            return 0;
        }




    }
}
