using Blog.Repositories;
using System;

namespace Blog.Screens.ReportScreens
{
    internal class PostsTagsReportScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de posts | tags");
            Console.WriteLine("-------------");
            List();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ReadKey();
            MenuReportScreen.Load();
        }
        internal static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithTags();
            foreach (var item in posts)
            {
                //var roles = string.Join(", ", item.Roles.Select(r => r.Name));
                Console.WriteLine($"{item.Title} - Tags: []");
            }
        }
    }
}