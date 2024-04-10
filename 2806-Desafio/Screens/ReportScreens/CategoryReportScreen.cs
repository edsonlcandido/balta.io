using Blog.Repositories;
using System;
using System.Collections.Generic;

namespace Blog.Screens.ReportScreens
{
    internal class CategoryReportScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatório de Categorias (quant. posts)");
            Console.WriteLine("-------------");
            List();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.ReadKey();
            MenuReportScreen.Load();

        }

        private static void List()
        {
            var repository = new CategoryRepository(Database.Connection);
            var categoriesPost = repository.GetCategoryPosts();
            foreach (var item in categoriesPost)
            {
                Console.WriteLine($"{item.CategoryName} ({item.PostCount})");
            }
        }
    }
}
