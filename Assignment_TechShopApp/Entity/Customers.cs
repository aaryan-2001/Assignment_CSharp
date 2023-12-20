using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Entity
{
    public class Customers
    {
        // Private attributes
        private int customerID;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;

        public int CustomerID { get { return customerID; } set { customerID = value; } }

        public string FirstName { get { return firstName; } set { firstName = value; } }


        public string LastName { get { return lastName; } set { lastName = value; } }

        public string Email { get { return email; } set { email = value; } }

        public string Phone { get { return phone; } set { phone = value; } }

        public string Address { get { return address; } set { address = value; } }

        // Constructor

        public Customers() { }   

        public Customers(int customerID, string firstName, string lastName, string email, string phone, string address)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }


        // Override ToString method
        public override string ToString()
        {
            return $"CustomerID: {CustomerID}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {Phone}, Address: {Address}";
        }


    }
}
