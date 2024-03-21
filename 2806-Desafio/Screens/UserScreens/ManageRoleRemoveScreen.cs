using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;
using System;

namespace Blog.Screens.UserScreens
{
    internal class ManageRoleRemoveScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Remover função");
            Console.WriteLine("-----------------");
            //selecione o autor
            Console.WriteLine("");
            Console.WriteLine("Lista de autores");
            Console.WriteLine("-----------------");
            ListUserScreen.List();
            Console.WriteLine(
                "Selecione o Id do autor: ");
            var userId = Console.ReadLine();
            Console.WriteLine("");
            //Console.WriteLine("Lista de funções do usuário");
            //Console.WriteLine("-----------------");
            ListRoles(int.Parse(userId));
            Console.WriteLine("Selecione o Id da função: ");
            var roleId = Console.ReadLine();
            Remove(new UserRole
            {
                RoleId = int.Parse(roleId),
                UserId = int.Parse(userId)
            }
                       );
            Console.ReadKey();
            MenuManageRoleScreen.Load();
        }
        private static void Remove(UserRole userRole)
        {
            try
            {
                var repository = new UserRoleRepository(Database.Connection);
                repository.DeleteRole(userRole);
                Console.WriteLine("Função removida com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel remover a função");
                Console.WriteLine(ex.Message);
            }
        }
        private static void ListRoles(int userId)
        {
            var repository = new UserRepository(Database.Connection);
            var user = repository.GetWithRoles(userId);
            Console.WriteLine($"Funções do usuário {user.Name}");
            foreach (var role in user.Roles)
                Console.WriteLine($"{role.Id} - {role.Name}");
        }

    }
}