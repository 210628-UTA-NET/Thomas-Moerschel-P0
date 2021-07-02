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

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.ShowCustomerMenu;
                case "2":
                    return MenuType.AddCustomerMenu;
                default:
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                    return MenuType.CustomerMenu;
            }
        }
    }
}