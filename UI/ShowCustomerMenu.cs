using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class ShowCustomerMenu : IMenu
    {
        private ICustomerBL _customerBL;
        public ShowCustomerMenu(ICustomerBL p_customer)
        {
            _customerBL = p_customer;
        }
        public void Menu()
        {
            Console.WriteLine("List of Customers:");

            List <Customer> customers = _customerBL.GetAllCustomers();

            foreach (Customer cust in customers)
            {
                Console.WriteLine("===================");
                Console.WriteLine(cust);
            }
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
                    Console.WriteLine("Improper Input");
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    return MenuType.CustomerMenu;
            }
        }
    }
}