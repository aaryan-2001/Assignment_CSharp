using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_TechShopApp.Utility
{
    internal class DbConnUtil
    {
        private static IConfiguration _iconfiguration;
        static DbConnUtil()
        {
            GetAppSettingsFile();
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath("E:/VISUAL STUDIO ASPNET/Repository/Assignment_TechShopApp/Assignment_TechShopApp")
                        .AddJsonFile("Appsettings.json");
            _iconfiguration = builder.Build();

        }
        public static string GetConnectionString()
        {
            return _iconfiguration.GetConnectionString("LocalConnectionString");
        }
    }

}
