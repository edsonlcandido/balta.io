using Blog.Models;
using Blog.Repositories;
using System;

namespace Blog.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova tag");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: {0}", name.ToSlug());
            //se a tecla apertada for o backspace apaga verdadeiro
            const char BACKSPACE = (char)8;
            var key = Console.ReadKey();
            string slug;

            if (key.KeyChar == BACKSPACE)
            {
                //preenche na linha e permite editar o slug
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("Slug: ");
                slug = Console.ReadLine();
            }
            else
            {
                slug = name.ToSlug();
                Console.WriteLine("");
            }
            

            Create(new Tag
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}