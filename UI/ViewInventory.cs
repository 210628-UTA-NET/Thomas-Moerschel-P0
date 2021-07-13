using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class ViewInventory : IMenu
    {
        private IInventory _InventoryBL;
        public static StoreFront store = new StoreFront();
        public ViewInventory(){}
        public ViewInventory(IInventory p_InventoryBL)
        {
            _InventoryBL = p_InventoryBL;
        }
        public void storeLocation(StoreFront p_storeFront)
        {
            store = p_storeFront;
        }
        public void Menu()
        {
            Console.WriteLine("Inventory List");
            Console.WriteLine("================");
            List<LineItems> lineItems = _InventoryBL.GetInventory(store);
            foreach (LineItems item in lineItems)
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------");
            }
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
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    return MenuType.ViewInventory;
            }
        }
    }
}