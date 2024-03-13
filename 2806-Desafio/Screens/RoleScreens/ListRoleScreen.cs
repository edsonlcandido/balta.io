using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.Screens.RoleScreens
{
    internal class ListRoleScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de funções");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Role>(Database.Connection);
            var roles = repository.Get();
            foreach (var item in roles)
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Slug}");
        }
    }
}
