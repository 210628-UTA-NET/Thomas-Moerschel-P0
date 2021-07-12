using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class AddInventory : IMenu
    {
        private IInventory _InventoryBL;
        public static StoreFront store = new StoreFront();
        public AddInventory(){}
        public AddInventory(IInventory p_InventoryBL)
        {
            _InventoryBL = p_InventoryBL;
        }
        public void storeLocation(StoreFront p_storeFront)
        {
            store = p_storeFront;
        }
        public void Menu()
        {
            List<LineItems> lineItems = _InventoryBL.GetInventory(store);
            Console.WriteLine(store.Name + " Inventory Manager");
            Console.WriteLine("Which Inventory Item would you like to restock?");
            Console.WriteLine("Inventory List:");
            Console.WriteLine("---------------");
            foreach (LineItems item in lineItems)
            {
                Console.WriteLine(item);
                Console.WriteLine("---------------");
            }
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            List<LineItems> lineItems = _InventoryBL.GetInventory(store);
            string userInput = Console.ReadLine();
            foreach (LineItems item in lineItems)
            {
                if (userInput == item.Id.ToString() || item.Product == userInput)
                {
                    Console.WriteLine("How much would you like to add?");
                    string quantity = Console.ReadLine();
                    _InventoryBL.AddInventory(item, Int16.Parse(quantity));
                    return MenuType.StoreFrontInventoryMenu;
                }                
            }
            return MenuType.ViewInventory;


    

            
           
        }
    }
}