using System;

namespace StoreApp
{
    public class StoreFrontMenu : IMenu
    {
        public string _location { get; set; }
        public static StoreFrontMenu newMenu = new StoreFrontMenu();
        public void storeLocation(StoreFront p_storeFront){
            newMenu._location = p_storeFront.Name;
        }
        public void Menu() 
        {
            Console.WriteLine("Welcome to " + newMenu._location);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[3] View Order History");
            Console.WriteLine("[2] Manage Inventory");
            Console.WriteLine("[1] Find a Different StoreFront");
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
                    newMenu._location = "";
                    return MenuType.FindStoreFrontMenu;
                case "2":
                    return MenuType.StoreFrontInventoryMenu;
                case "3":
                  //  return MenuType.StoreFrontOrderHistory
                case "4":
                    return MenuType.OrderMenu;
                default:
                    return MenuType.StoreFrontMenu;
            }
        }
    }
}