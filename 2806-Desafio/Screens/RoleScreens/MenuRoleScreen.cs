using Blog.Screens.MainScreens;
using Blog.Screens.UserScreens;
using System;

namespace Blog.Screens.RoleScreens
{
    internal static class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gest�o de Fun��es");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar fun��es");
            Console.WriteLine("2 - Criar nova fun��o");
            Console.WriteLine("3 - Atualizar uma fun��o");
            Console.WriteLine("4 - Deletar uma fun��o");
            Console.WriteLine("0 - Menu inicial");
            Console.WriteLine();
            Console.WriteLine();

            var input = Console.ReadLine();
            short option;
            if (!short.TryParse(input, out option))
            {
                MenuRoleScreen.Load();
                return;
            }

            switch (option)
            {
                case 1:
                    ListRoleScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
                    break;
                case 0:
                    MainMenuScreen.Load();
                    break;
                default: MenuRoleScreen.Load(); break;
            }
        }
    }
}
