using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Screens.MainScreens;
using Blog.Screens.UserScreens;

namespace Blog.Screens.PostScreens
{
    public static class AddPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova postagem");
            Console.WriteLine("-----------------");
            Console.Write("Titulo: ");
            var title = Console.ReadLine();
            Console.Write("Postagem: ");
            var body = Console.ReadLine();
            //tranform title in url scape and replace space for -
            var slug = title.ToSlug();
            var summary = body.ToSummary();

            //selecione a categoria
            ListCategoryScreen.List();

            Console.Write("Selecione o Id da categoria: ");
            var categoryId = Console.ReadLine();

            //selecione o autor
            ListUserScreen.List();

            Console.Write("Selecione o Id do autor: ");
            var authorId = Console.ReadLine();

            Create(new Post
            {
                Title = title,
                Body = body,
                Slug = slug,
                Summary = summary,
                CategoryId = int.Parse(categoryId),
                AuthorId = int.Parse(authorId)
            });
            Console.ReadKey();
            MainMenuScreen.Load();

        }
        public static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Postagem cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a postagem");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

