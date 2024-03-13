using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.Screens.RoleScreens
{
    internal class CreateRoleScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova função");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Role
            {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Create(role);
                Console.WriteLine("Função cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar a função");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
