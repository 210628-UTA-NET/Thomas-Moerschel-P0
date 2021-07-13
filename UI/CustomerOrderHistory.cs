using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class CustomerOrderHistory : IMenu
    {
        public static Customer customerOrderHistory = new Customer();
        private IOrderBL _OrderBL;
        public CustomerOrderHistory(){}
        public CustomerOrderHistory(IOrderBL p_OrderBL)
        {
            _OrderBL = p_OrderBL;
        }
        public void customerInformation (Customer p_customer)
        {
            customerOrderHistory = p_customer;
        }
        public void Menu()
        {
            List <Orders> orderHistory = _OrderBL.GetOrders(customerOrderHistory);
            //need functionality to find customer to display their order history, you could do that here or make a new .cs file similar to FindStoreLocation which prompts for user information (find customer, if not add customer) before coming to this menu
            Console.WriteLine("==================================================");
            Console.WriteLine(customerOrderHistory.Name + "'s Order History");
            Console.WriteLine("==================================================");
            Console.WriteLine("--------------------------------------------------");
            foreach (Orders order in orderHistory)
            {
                Console.WriteLine(order);
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine("==================================================");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                        customerOrderHistory.Name = "";
                        customerOrderHistory.Address = "";
                        customerOrderHistory.Email = "";
                        customerOrderHistory.PhoneNumber = "";
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("========================");
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press ENTER to Continue");
                    Console.WriteLine("========================");
                    Console.ReadLine();
                    return MenuType.CustomerOrderHistory;

            }
        }
    }
}