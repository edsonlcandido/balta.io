using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using System;
using System.Linq;

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
            var repository = new UserRepository(Database.Connection);
            var users = repository.GetWithRoles();
            //transformar a lista de roles em uma string
            
            foreach (var item in users)
            {               
                var roles = string.Join(", ", item.Roles.Select(r=>r.Name));                
                Console.WriteLine($"{item.Id} - {item.Name} - Funções: {roles} ");
            }

                
        }
    }
}