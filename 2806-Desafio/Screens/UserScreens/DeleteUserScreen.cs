using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using System;

namespace Blog.Screens.UserScreens
{
    internal class DeleteUserScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir um usuário");
            Console.WriteLine("-------------");
            Console.Write("Qual o id do usuário que deseja exluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário exluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir o usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}