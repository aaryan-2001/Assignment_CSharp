using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Exceptions
{
    internal class AuthenticationException : Exception
    {
        public AuthenticationException() : base("Authentication failed. User not authenticated.")
        {
        }
    }

    internal class AuthorizationException : Exception
    {
        public AuthorizationException() : base("Authorization failed. Insufficient permissions.")
        {
        }

        public AuthorizationException(string message) : base(message)
        {
        }
    }

    

    }
