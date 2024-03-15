using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;
using System;

namespace Blog.Screens.TagScreens
{
    public static class UpdateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando uma tag");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();
            var repository = new Repository<Tag>(Database.Connection);
            var tag = repository.Get(int.Parse(id));
            Console.Write("Nome: {0}", tag.Name);
            //se a tecla apertada for o backspace apaga verdadeiro
            const char BACKSPACE = (char)8;
            var key = Console.ReadKey();
            string name;

            if (key.KeyChar == BACKSPACE)
            {
                //preenche na linha e permite editar o slug
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write("Nome: ");
                name = Console.ReadLine();
            }
            else
            {
                name = tag.Name;
                Console.WriteLine("");
            }
            Console.Write("Slug: {0}", tag.Slug);
            //se a tecla apertada for o backspace apaga verdadeiro
            var slugKey = Console.ReadKey();
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
                slug = tag.Slug;
                Console.WriteLine("");
            }

            Update(new Tag
            {
                Id = int.Parse(id),
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        public static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Update(tag);
                Console.WriteLine("Tag atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}