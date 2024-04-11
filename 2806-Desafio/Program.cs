using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;
using System;
using System.IO;
using Blog.Screens.MainScreens;
using Microsoft.Extensions.Configuration;
using Blog.Models;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace Blog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            string server = configuration["DatabaseSettings:Server"];
            int port = int.Parse(configuration["DatabaseSettings:Port"]);
            string user = configuration["DatabaseSettings:User"];
            string database = configuration["DatabaseSettings:Database"];
            string password = configuration["DatabaseSettings:Password"];

            //string CONNECTION_STRING = @$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Blog";
            string CONNECTION_STRING = @$"Data Source={server},{port};TrustServerCertificate=true;Encrypt=false;Initial Catalog={database};User ID={user};Password={password};";

            MainMenuScreen.Load();

            Console.ReadKey();
            Database.Connection.Close();
        }
    }
}
