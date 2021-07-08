using System;

namespace StoreApp
{
    public class MakeAnOrder : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("This is where a customer can place an order");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.CustomerFindStoreFrontMenu;
                default:
                    return MenuType.MakeAnOrder;
            }
        }
    }
}