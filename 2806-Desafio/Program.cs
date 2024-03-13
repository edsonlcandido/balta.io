using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;
using System;
using System.IO;
using Blog.Screens.MainScreens;

namespace Blog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string CONNECTION_STRING = @$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Blog";

            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            MainMenuScreen.Load();

            Console.ReadKey();
            Database.Connection.Close();
        }

    }
}
