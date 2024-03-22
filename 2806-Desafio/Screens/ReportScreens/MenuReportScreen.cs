using Blog.Screens.MainScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.ReportScreens
{
    internal class MenuReportScreen
    {
        internal static void Load()
        {
            Console.Clear();
            Console.WriteLine("Relatórios");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("* - Relatório Categoria (Quant. posts)");
            Console.WriteLine("* - Relatório Tags (Quant. posts)");
            Console.WriteLine("* - Relatório Posts da categoria");
            Console.WriteLine("4 - Relatório Posts - categoria");
            Console.WriteLine("5 - Relatório Posts - tags");
            Console.WriteLine("0 - Menu inicial");
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
                    //CategoryReportScreen.Load();
                    break;
                case 2:
                    //TagsReportScreen.Load();
                    break;
                case 3:
                    //PostCategoryReportScreen.Load();
                    break;
                case 4:
                    PostCategoryReportScreen.Load();
                    break;
                case 5:
                    PostsTagsReportScreen.Load();
                    break;
                case 0:
                    MainMenuScreen.Load();
                    break;
                default: MainMenuScreen.Load(); break;
            }
        }
    }
}
