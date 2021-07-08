using System;
namespace StoreApp
{
    public class StoreOrderHistory : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Store Order History");
            Console.WriteLine("-------------------");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.StoreFrontMenu;
                default:
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                    return MenuType.StoreOrderHistory;
            }
        }
    }
}