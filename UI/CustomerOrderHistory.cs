using System;
namespace StoreApp
{
    public class CustomerOrderHistory : IMenu
    {
        public void Menu()
        {
            //need functionality to find customer to display their order history, you could do that here or make a new .cs file similar to FindStoreLocation which prompts for user information (find customer, if not add customer) before coming to this menu
            Console.WriteLine("Customer Order History");
            Console.WriteLine("----------------------");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.CustomerMenu;
                default:
                    return MenuType.CustomerOrderHistory;

            }
        }
    }
}