using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.Screens.CategoryScreens
{
    internal class UpdateCategoryScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma categoria");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            var repository = new Repository<Category>(Database.Connection);
            var category = repository.Get(int.Parse(id));

            category.Name = name;
            category.Slug = slug;

            Update(category);

            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        private static void Update(Category category)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Update(category);
                Console.WriteLine("Categoria atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a categoria");
                Console.WriteLine(ex.Message);                
            }
        }
    }
}
