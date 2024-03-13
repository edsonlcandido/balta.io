using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.Screens.CategoryScreens
{
    internal class ListCategoryScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de categorias");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Category>(Database.Connection);
            var categories = repository.Get();
            foreach (var item in categories)
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Slug}");
        }
    }
}
