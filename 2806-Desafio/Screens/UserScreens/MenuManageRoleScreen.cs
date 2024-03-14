using Blog.Screens.MainScreens;
using System;

namespace Blog.Screens.UserScreens
{
    internal class MenuManageRoleScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de funções dos usuários");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Adicionar função");
            Console.WriteLine("2 - Remover função");
            Console.WriteLine("0 - Menu inicial");
            Console.WriteLine();
            Console.WriteLine();
            var input = Console.ReadLine();
            short option;
            if (!short.TryParse(input, out option))
            {
                MenuUserScreen.Load();
                return;
            }

            switch (option)
            {
                case 1:
                    ManageRoleAddScreen.Load();
                    break;
                case 2:
                    ManageRoleRemoveScreen.Load();
                    break;
                case 0:
                    MainMenuScreen.Load();
                    break;
                default: MainMenuScreen.Load(); break;
            }
        }
    }
}