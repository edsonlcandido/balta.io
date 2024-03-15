using Blog.Repositories;
using System;
using System.Collections.Generic;

namespace Blog.Screens.ReportScreens
{
    internal class PostCategoryReportScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de posts | categoria");
            Console.WriteLine("-------------");
            List();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ReadKey();
            MenuReportScreen.Load();

        }

        private static void List()
        {
            var repository = new PostRepository(Database.Connection);
            var posts = repository.GetWithCategoryAuthor();
            foreach (var item in posts)
            {
                Console.WriteLine($"Post: {item.Id}. {item.Title} - Categoria: {item.Category.Name} - Autor: {item.Author.Name}");
            }
        }
    }
}