using System;

namespace StoreApp
{
    public class AddInventory : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the Inventory Management System");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.StoreFrontInventoryMenu;
                default:
                    Console.WriteLine("Improper Input");
                    Console.WriteLine("press any key to continue");
                    Console.ReadLine();
                    return MenuType.AddInventory;

            }
        }
    }
}