using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu custMenu = new MainMenu();
            bool repeat = true;
            MenuType currentMenu = MenuType.MainMenu;
            IFactory menuFactory = new MenuFactory();

            while (repeat)
            {
                Console.Clear();
                custMenu.Menu();
                currentMenu = custMenu.UserInput();

                switch (currentMenu)
                {
                    case MenuType.MainMenu:
                        custMenu = menuFactory.GetMenu(MenuType.MainMenu);
                        break;
                    case MenuType.CustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerMenu);
                        break;
                    case MenuType.ShowCustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.ShowCustomerMenu);
                        break;
                    case MenuType.AddCustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.AddCustomerMenu);
                        break;
                    case MenuType.Exit:
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Cannot process Input... Please Try again.");
                        break;
                }
            }
        
        }
    }

}    