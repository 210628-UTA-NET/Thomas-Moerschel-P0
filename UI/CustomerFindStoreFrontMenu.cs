using System;
namespace StoreApp
{
    public class CustomerFindStoreFrontMenu : IMenu
    {
        StoreFront store1 = new StoreFront("Atlanta's Luxery Clothing Outlet", "Atlanta, Georgia");
        StoreFront store2 = new StoreFront("Fort Myers' Luxery Clothing Outlet", "Fort Myers, Florida");
        StoreFront store3 = new StoreFront("Gainesville's Luxery Cloting Outlet", "Gainesville, Florida");
        public void Menu()
        {
            Console.WriteLine("Please choose the location that you'd like to shop");
            Console.WriteLine("Choose from the following or type the city of your shop!");
            Console.WriteLine(string.Format("[3] {0}\n[2] {1}\n[1] {2}", store1, store2, store3));
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
                    return MenuType.CustomerValidation;
                default:
                    return MenuType.CustomerFindStoreFrontMenu;
            }
        }
    }
}