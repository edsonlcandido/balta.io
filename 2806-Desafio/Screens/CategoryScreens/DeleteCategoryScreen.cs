using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.Screens.CategoryScreens
{
    internal class DeleteCategoryScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma categoria");
            Console.WriteLine("-------------");
            Console.Write("Qual o id da categoria que deseja exluir? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Categoria exlu�da com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("N�o foi poss�vel exluir a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
