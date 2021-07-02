using System;
using System.Threading;

namespace StoreApp
{
    public class CustomerMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Customer Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[2] Add a Customer");
            Console.WriteLine("[1] Retrieve a List of Admitted Customers");
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
                    //Changes "UserInput" wihtin main to MenuType.AddCustomerMenu, bringing the user to AddCustomerMenu
                    return MenuType.AddCustomerMenu;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    //invalid input, stays within current menu by returning its reference to main-> (MenuType.CustomerMenu)
                    return MenuType.CustomerMenu;
            }
        }
    }
}