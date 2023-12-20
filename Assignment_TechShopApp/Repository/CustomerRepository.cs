using Assignment_TechShopApp.Entity;
using Assignment_TechShopApp.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Repository
{
    public class CustomerRepository: ICustomerInterface
    {
        public List<Customers> Customer = new List<Customers>();
        public string connectionString;
        SqlCommand command = null;

        //constructor
        public CustomerRepository()
        {
            connectionString = DbConnUtil.GetConnectionString();
            command = new SqlCommand();
        }

        public int CalculateTotalOrders(int customerId) 
        {
            try
            {
                using(SqlConnection  sqlConnection = new SqlConnection(connectionString)) 
                {
                    sqlConnection.Open();
                    string query = "SELECT COUNT(*) FROM Orders WHERE CustomerId = @CustomerId";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);

                        var result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int totalOrders))
                        {
                            return totalOrders;
                        }

                    }

                }

            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return 0;
        }



        public void UpdateCustomerInfo(int customerId, string email, string phone, string address)
        {
            try 
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string query = "UPDATE Customers SET Email = @Email, Phone = @Phone, Address = @Address WHERE CustomerId = @CustomerId";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Phone", phone);
                        command.Parameters.AddWithValue("@Address", address);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public Customers GetCustomerinfo(int customerId)
        {
            try 
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    string query = "SELECT * FROM Customers WHERE CustomerID = @CustomerId";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Customers
                                {
                                    CustomerID = (int)reader["CustomerId"],
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Email = reader["Email"].ToString(),
                                    Phone = reader["Phone"].ToString(),
                                    Address = reader["Address"].ToString()
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
