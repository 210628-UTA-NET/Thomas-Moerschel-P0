using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class CustomerValidation : IMenu
    {
        private ICustomerBL _customerBL;

        public CustomerValidation(ICustomerBL p_customerBL) 
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("Are you a new or returning customer?");
            Console.WriteLine("[2] New Customer");
            Console.WriteLine("[1] Returning Customer");
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
                    List <Customer> customers = _customerBL.GetAllCustomers();
                    Console.WriteLine("Please Input your full name:");
                    string tempName = Console.ReadLine();
                    foreach (Customer cust in customers)
                    {
                        if (tempName == cust.Name)
                        {
                            return MenuType.MakeAnOrder; //pass over customer information
                        }
                    }
                    Console.WriteLine("Name not found, try adding a new customer");
                        return MenuType.CustomerValidation;
                case "2":
                   //collect customer information and use AddCustomer from the BL to admit them to the database, then pass that object infomration to the MakeAnOrder menu
                default:
                    return MenuType.CustomerValidation;

            }
        }
    }
}