using System;

namespace StoreApp
{
    public class StoreFrontInventoryMenu : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Welcome to the --StoreFront Name TBD-- Inventory Managment Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[2] View Inventory");
            Console.WriteLine("[1] Replenish Inventory");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            throw new NotImplementedException();
        }
    }
}