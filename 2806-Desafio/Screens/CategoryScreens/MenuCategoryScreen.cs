using Blog.Screens.MainScreens;
using System;

namespace Blog.Screens.CategoryScreens
{
    internal class MenuCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de categorias");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar categorias");
            Console.WriteLine("2 - Cadastrar categoria");
            Console.WriteLine("3 - Atualizar categoria");
            Console.WriteLine("4 - Excluir categoria");
            Console.WriteLine("0 - Menu inicial");
            Console.WriteLine();
            Console.WriteLine();
            var input = Console.ReadLine();
            short option;
            if (!short.TryParse(input, out option))
            {
                MenuCategoryScreen.Load();
                return;
            }

            switch (option)
            {
                case 1:
                    ListCategoryScreen.Load();
                    break;
                case 2:
                    CreateCategoryScreen.Load();
                    break;
                case 3:
                    UpdateCategoryScreen.Load();
                    break;
                case 4:
                    DeleteCategoryScreen.Load();
                    break;
                case 0:
                    MainMenuScreen.Load();
                    break;
                default: MainMenuScreen.Load(); break;
            }
        }
    }
}
