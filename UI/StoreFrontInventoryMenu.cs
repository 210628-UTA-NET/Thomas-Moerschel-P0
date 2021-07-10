using System;

namespace StoreApp
{
    public class StoreFrontInventoryMenu : IMenu
    {
        public static StoreFront store = new StoreFront();
        public void storeLocation(StoreFront p_storeFront)
        {
            store = p_storeFront;
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to " + store.Name + " Inventory Managment Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[2] View Inventory");
            Console.WriteLine("[1] Replenish Inventory");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            ViewInventory location = new ViewInventory();

            switch (userInput)
            {
                case "0":
                    return MenuType.StoreFrontMenu;
                case "1":
                    return MenuType.AddInventory;
                case "2":
                    location.storeLocation(store);
                    return MenuType.ViewInventory;
                default:
                    return MenuType.StoreFrontInventoryMenu;
            }
        }
    }
}