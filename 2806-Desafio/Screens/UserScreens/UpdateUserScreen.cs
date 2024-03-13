using Blog.Models;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using System;

namespace Blog.Screens.UserScreens
{
    internal class UpdateUserScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Atualizando um usuário");
            Console.WriteLine("-------------");
            Console.Write("Id: ");
            var id = Console.ReadLine();

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Bio: ");
            var bio = Console.ReadLine();

            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get(int.Parse(id));

            user.Name = name;
            user.Slug = slug;
            user.Email = email;
            user.Bio = bio;

            Update(user);

            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Update(user);
                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário");
                Console.WriteLine(ex.Message);                
            }

            
        }
    }
}