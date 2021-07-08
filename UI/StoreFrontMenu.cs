using System;

namespace StoreApp
{
    public class StoreFrontMenu : IMenu
    {
        public static StoreFront store = new StoreFront();
        public void storeLocation(StoreFront p_storeFront){
            store.Name = p_storeFront.Name;
        }
        public void Menu() 
        {
            Console.WriteLine("Welcome to " + store.Name);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[3] View Order History");
            Console.WriteLine("[2] Manage Inventory");
            Console.WriteLine("[1] Find a Different StoreFront");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            StoreFrontInventoryMenu location = new StoreFrontInventoryMenu();
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.FindStoreFrontMenu;
                case "2":
                    location.storeLocation(store);
                    return MenuType.StoreFrontInventoryMenu;
                case "3":
                    return MenuType.StoreOrderHistory;
                default:
                    return MenuType.StoreFrontMenu;
            }
        }
    }
}