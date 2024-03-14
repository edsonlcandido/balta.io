using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using System;

namespace Blog.Screens.UserScreens
{
    internal class ListUserScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista usuários");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var users = repository.Get();
            foreach (var item in users)
                Console.WriteLine($"{item.Id} - {item.Name} - Funções: ... ");
        }
    }
}