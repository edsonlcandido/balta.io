using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.Screens.RoleScreens
{
    internal class DeleteRoleScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma função");
            Console.WriteLine("-------------");
            Console.Write("Qual o id da função que deseja exluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Função exluída com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir a função");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
