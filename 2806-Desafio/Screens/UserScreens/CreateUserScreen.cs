using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using System;

namespace Blog.Screens.UserScreens
{
    internal class CreateUserScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo usuario");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Console.Write("Password: ");
            var passwordHash = Console.ReadLine();

            Console.Write("Bio: ");
            var bio = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Image: ");
            var image = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Slug = slug,
                PasswordHash = passwordHash,
                Bio = bio,
                Email = email,
                Image = image
            });

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usuario cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel salvar o usuario");
                Console.WriteLine(ex.Message);
            }
        }
    }
}