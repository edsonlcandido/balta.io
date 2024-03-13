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
            Console.WriteLine("Excluir uma fun��o");
            Console.WriteLine("-------------");
            Console.Write("Qual o id da fun��o que deseja exluir? ");
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
                Console.WriteLine("Fun��o exlu�da com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("N�o foi poss�vel exluir a fun��o");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
