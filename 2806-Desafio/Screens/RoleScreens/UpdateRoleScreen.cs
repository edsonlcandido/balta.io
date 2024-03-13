using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.Screens.RoleScreens
{
    internal class UpdateRoleScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma função");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            var repository = new Repository<Role>(Database.Connection);
            var role = repository.Get(int.Parse(id));

            role.Name = name;

            Update(role);

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Update(role);
                Console.WriteLine("Função atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a função");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
