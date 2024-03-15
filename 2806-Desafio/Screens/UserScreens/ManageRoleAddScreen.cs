using Blog.Models;
using Blog.Repositories;
using Blog.Screens.RoleScreens;
using System;
using System.Data;

namespace Blog.Screens.UserScreens
{
    internal class ManageRoleAddScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Adicionar função");
            Console.WriteLine("-----------------");
            //selecione o autor
            Console.WriteLine("");
            Console.WriteLine("Lista de autores");
            Console.WriteLine("-----------------");
            ListUserScreen.List();

            Console.Write("Selecione o Id do autor: ");
            var userId = Console.ReadLine();

            Console.WriteLine("");
            Console.WriteLine("Lista de funções");
            Console.WriteLine("-----------------");
            ListRoleScreen.List();
            Console.Write("Selecione o Id da função: ");
            var roleId = Console.ReadLine();

            Add(new UserRole
                {
                    RoleId = int.Parse(roleId),
                    UserId = int.Parse(userId)
                }
            );

            Console.ReadKey();
            MenuManageRoleScreen.Load();
        }

        private static void Add(UserRole userRole)
        {
            try
            {
                var repository = new Repository<UserRole>(Database.Connection);
                repository.Create(userRole);
                Console.WriteLine("Função adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel adcionar a função");
                Console.WriteLine(ex.Message);
            }
        }
    }
}