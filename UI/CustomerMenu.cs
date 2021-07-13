using System;
using System.Threading;

namespace StoreAppUI
{
    public class CustomerMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to the Customer Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("===========================================");
            Console.WriteLine("[4] View a Customer's Order History");
            Console.WriteLine("[3] Add a Customer");
            Console.WriteLine("[2] Search for a Customer");
            Console.WriteLine("[1] Retrieve a List of Admitted Customers");
            Console.WriteLine("===========================================");
            Console.WriteLine("[0] Go Back");
        }
        //Accessed via the "CustomerMenu" case within the main's switch statement, functionality controls menu naviation
        public MenuType UserInput()
        {
            //takes user input and stores it within the string "user input" to navigate CustomerMenu.Menu()
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    //Changes "UserInput" within main to MenuType.MainMenu bringing user to MainMenu
                    return MenuType.MainMenu;
                case "1":
                    //Changes "UserInput" within main to MenuType.ShowCustomerMenu, bringing the user to ShowCustomerMenu
                    return MenuType.ShowCustomerMenu;
                case "2":
                    //Changes "UserInput" within main to MenuType.SearchCustomerMenu, bringing the user to SearchCustomerMenu
                    return MenuType.SearchCustomerMenu;
                case "3":
                    return MenuType.AddCustomerMenu;
                case "4":
                    return MenuType.SearchCustomerOrderHistory;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    //invalid input, stays within current menu by returning its reference to main-> (MenuType.CustomerMenu)
                    return MenuType.CustomerMenu;
            }
        }
    }
}