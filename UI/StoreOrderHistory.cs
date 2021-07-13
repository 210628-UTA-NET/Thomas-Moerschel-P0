using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class StoreOrderHistory : IMenu
    {
        private IOrderBL _OrderBL;
        public StoreOrderHistory(){}
        public StoreOrderHistory(IOrderBL p_OrderBL){
            _OrderBL = p_OrderBL;
        }
        public static StoreFront store = new StoreFront();
        public void storeLocation(StoreFront p_storeFront)
        {
            store = p_storeFront;
        }
        public void Menu()
        {
            List <Orders> storeOrders = _OrderBL.GetOrders(store);
            Console.WriteLine(store.Name + " Order History");
            Console.WriteLine("=================================================");
            foreach (Orders order in storeOrders)
            {
                Console.WriteLine(order);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("=================================================");
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