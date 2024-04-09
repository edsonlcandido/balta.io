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

            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            var query = @"
                SELECT [Post].*,
                    [Tag].*
                FROM [PostTag]
                    LEFT JOIN [Post] ON [Post].[Id] = [PostTag].[PostId]
                    LEFT JOIN [Tag] ON [Tag].[Id] = [PostTag].[TagId]";

            var posts = new List<Post>();

            var items = Database.Connection.Query<Post, Tag, Post>(
                    query,
                    (post, tag) =>
                    {
                        var p = posts.FirstOrDefault(x => x.Id == post.Id);
                        if (p == null)
                        {
                            p = post;
                            if (tag != null)
                                p.Tags.Add(tag);
                            posts.Add(post);
                        }
                        else
                        p.Tags.Add(tag);
                        return p;
                    },
                    splitOn: "Id");

            MainMenuScreen.Load();

            Console.ReadKey();
            Database.Connection.Close();
        }
    }
}
