using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.MainScreens
{
    internal static class MainMenuScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Adicionar postagem");
            Console.WriteLine("6 - Vincular perfil/usuário");
            Console.WriteLine("7 - Vincular post/tag");
            Console.WriteLine("8 - Relatórios");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.WriteLine();
            var input = Console.ReadLine();
            short option;
            if (!short.TryParse(input, out option))
            {
                Load();
                return;
            }

            switch (option)
            {
                case 1:
                    UserScreens.MenuUserScreen.Load();
                    break;
                case 2:
                    RoleScreens.MenuRoleScreen.Load();
                    break;
                case 3:
                    CategoryScreens.MenuCategoryScreen.Load();
                    break;
                case 4:
                    TagScreens.MenuTagScreen.Load();
                    break;
                case 5:
                    PostScreens.AddPostScreen.Load();
                    break;
                case 6:
                    UserScreens.MenuManageRoleScreen.Load();
                    break;
                case 7:
                    PostScreens.MenuPostTagScreen.Load();
                    break;
                case 8:
                    ReportScreens.MenuReportScreen.Load();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default: Load(); break;
            }
        }
    }
}
