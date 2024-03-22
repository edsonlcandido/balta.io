using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;
using System;
using System.IO;
using Blog.Screens.MainScreens;
using Dapper;
using Blog.Models;
using System.Linq;
using System.Collections.Generic;

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
