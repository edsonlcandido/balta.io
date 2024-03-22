using Blog.Models;
using Blog.Repositories;
using Blog.Screens.ReportScreens;
using Blog.Screens.TagScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.PostScreens
{
    internal static class MenuPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Adicionar tags a postagem");
            Console.WriteLine("-----------------");
            PostCategoryReportScreen.List();
            Console.WriteLine("Digite o Id do post que deseja adicionar tags: ");
            var postId = Console.ReadLine();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("-------------");
            ListTagScreen.List();
            Console.Write("Digite o Id da tag que deseja adicionar: ");
            var tagId = Console.ReadLine();
            Add(new PostTag { PostId = int.Parse(postId), TagId = int.Parse(tagId) });
            Console.Write("Adicionar mais tags? (s/n)");
            var addMore = Console.ReadLine();
            if (addMore == "s")
            {
                Load();
            }
            else
            {
                Console.WriteLine("Tags adicionadas com sucesso!");
                Console.ReadKey();
                MenuReportScreen.Load();
            }


        }

        private static void Add(PostTag postTag)
        {
            try
            {
                var repository = new Repository<PostTag>(Database.Connection);
                repository.Create(postTag);
                Console.WriteLine("Tag adicionada com sucesso!");
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possivel adicionar a tag");
                throw;
            }
        }
    }
}
