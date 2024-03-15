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
            //string CONNECTION_STRING = @$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Blog";
            string CONNECTION_STRING = @$"Data Source=135.148.148.104,1433;TrustServerCertificate=true;Encrypt=false;Initial Catalog=Blog;User ID=blog_adm;Password=1q2w!Q@W;";

            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            MainMenuScreen.Load();

            Console.ReadKey();
            Database.Connection.Close();
        }
    }
}
