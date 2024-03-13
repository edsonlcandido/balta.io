using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.Screens.CategoryScreens
{
    internal class CreateCategoryScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova categoria");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Category
            {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Create(category);
                Console.WriteLine("Categoria cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar a categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
