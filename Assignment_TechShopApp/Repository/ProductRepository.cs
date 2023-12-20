using System;
using System.Collections.Generic;
using Assignment_TechShopApp.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Configuration;
using System.Data.SqlClient;
using Assignment_TechShopApp.Utility;

namespace Assignment_TechShopApp.Repository
{

    public class ProductRepository : IProductInterface
    {
        public List<Products> product = new List<Products>(); 

        public string connectionString;
        SqlCommand command = null;
        public ProductRepository() 
        {
            connectionString = DbConnUtil.GetConnectionString();
            command = new SqlCommand();
        }

        public void UpdateProductInfo(int productId, decimal price, string description)
        {
            try 
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string query = "UPDATE Products SET Price = @Price, Description = @Description WHERE ProductID = @ProductId";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Description", description);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public bool IsProductInStock(int productId)
        {
            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open ();
                    string query= "SELECT QuantityInStock FROM Inventory WHERE ProductId = @ProductId";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@ProductId", productId);

                        var result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int quantity))
                        {

                            if (quantity > 0)
                            {
                                Console.WriteLine(quantity);
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }

                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }



        public Products GetProductDetails(int productId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string query = "SELECT ProductId,ProductName, Price, Description FROM Products WHERE ProductID = @productId";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@productId", productId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Products
                                {
                                    ProductID = (int)reader["ProductId"],
                                    ProductName = reader["ProductName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = (decimal)reader["Price"],
                                   
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }





}

