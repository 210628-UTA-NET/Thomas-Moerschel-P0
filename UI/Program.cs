using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StoreAppUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a class instance of MainMenu and UPCASTS the reference to the type of interface
            //Interface type reference defines what you can access in the instance
            //In this instance, you can only use members of the class that the interface knows about.
            IMenu custMenu = new MainMenu();
            //to set condition for while statement
            bool repeat = true;
            //creates "current Menu" as enum MenuType (reference IMenu)
            MenuType currentMenu = MenuType.MainMenu;
            //Creates class instacne of MenuFactory and upcasts reference to interface type
            IFactory menuFactory = new MenuFactory();

            while (repeat)
            {
                 try
                {
                    Console.Clear();
                }
                catch(SystemException)
                {
                    Console.WriteLine ("Console.Clear exception caught!");
                }
                //calls Menu() from the MainMenu Object which displays a menu to the user
                custMenu.Menu();
                //Takes earlier IMenu Enum MenuType and calls UserInput method within MainMenu object
                currentMenu = custMenu.UserInput();
                //switches through user input defined within the MainMenu class and called in the previous line
                switch (currentMenu)
                {
                    case MenuType.MainMenu:
                        //custMenu object is set equal to the menuFactory.GetMenu() method which exports implementation and returns "new MainMenu()"-- jumps to main menu
                        custMenu = menuFactory.GetMenu(MenuType.MainMenu);
                        break;
                    case MenuType.CustomerMenu:
                        //calls Factory GetMenu() and returns CustomerMenu()
                        custMenu = menuFactory.GetMenu(MenuType.CustomerMenu);
                        break;
                    case MenuType.ShowCustomerMenu:
                        //calls Factory GetMenu() and returns ShowCustomerMenu()
                        custMenu = menuFactory.GetMenu(MenuType.ShowCustomerMenu);
                        break;
                    case MenuType.AddCustomerMenu:
                        // calls Factory GetMenu() and resturns AddCustomerMenu()
                        custMenu = menuFactory.GetMenu(MenuType.AddCustomerMenu);
                        break;
                    case MenuType.SearchCustomerMenu:
                        custMenu = menuFactory.GetMenu(MenuType.SearchCustomerMenu);
                        break;
                    case MenuType.StoreFrontMenu:
                        custMenu = menuFactory.GetMenu(MenuType.StoreFrontMenu);
                        break;
                    case MenuType.ManagementFindStoreFrontMenu:
                        custMenu = menuFactory.GetMenu(MenuType.ManagementFindStoreFrontMenu);
                        break;
                    case MenuType.StoreFrontInventoryMenu:
                        custMenu = menuFactory.GetMenu(MenuType.StoreFrontInventoryMenu);
                        break;
                    case MenuType.StoreOrderHistory:
                        custMenu = menuFactory.GetMenu(MenuType.StoreOrderHistory);
                        break;
                    case MenuType.AddInventory:
                        custMenu = menuFactory.GetMenu(MenuType.AddInventory);
                        break;
                    case MenuType.ViewInventory:
                        custMenu = menuFactory.GetMenu(MenuType.ViewInventory);
                        break;
                    case MenuType.CustomerOrderHistory:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerOrderHistory);
                        break;
                    case MenuType.CustomerFindStoreFrontMenu:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerFindStoreFrontMenu);
                        break;
                    case MenuType.MakeAnOrder:
                        custMenu = menuFactory.GetMenu(MenuType.MakeAnOrder);
                        break;
                    case MenuType.CustomerValidation:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerValidation);
                        break;
                    case MenuType.CustomerCheckout:
                        custMenu = menuFactory.GetMenu(MenuType.CustomerCheckout);
                        break;
                    case MenuType.PurchaseConfirmation:
                        custMenu = menuFactory.GetMenu(MenuType.PurchaseConfirmation);
                        break;
                    case MenuType.SearchCustomerOrderHistory:
                        custMenu = menuFactory.GetMenu(MenuType.SearchCustomerOrderHistory);
                        break;
                    case MenuType.Exit:
                        //ends condition of switch statement
                        repeat = false;
                        Console.WriteLine("Thank you for using the store application!");
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Cannot process Input... Please Try again.");
                        break;
                }
            }
        
        }
    }

}    