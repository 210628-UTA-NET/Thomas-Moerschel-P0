using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class SearchCustomerMenu : IMenu
    {
        public static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        
        public SearchCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("How would you like to search?");
            Console.WriteLine("[3] Search by Name");
            Console.WriteLine("[2] Search by Address");
            Console.WriteLine("[1] Search by Email");
            Console.WriteLine("[0] Go Back");
            
        }

        public MenuType UserInput()
        {
            List <Customer> customers = _customerBL.GetAllCustomers();
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    Console.WriteLine("Please Enter Customer Email:");
                    string email = Console.ReadLine();
                    foreach (Customer cust in customers)
                    {
                        if (email == cust.Email){
                            Console.WriteLine("Customer Found!");
                            Console.WriteLine("-----------------");
                            Console.WriteLine(cust);
                            Console.WriteLine("-----------------");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            return MenuType.SearchCustomerMenu;
                        }
                    }
                        Console.WriteLine("Customer Not Found!");
                        Console.ReadLine();
                        return MenuType.SearchCustomerMenu;
                    
                case "2":
                    Console.WriteLine("Please Enter Customer Address:");
                    string address = Console.ReadLine();
                    foreach (Customer cust in customers)
                    {
                        if (address == cust.Address){
                            Console.WriteLine("Customer Found!");
                            Console.WriteLine("-----------------");
                            Console.WriteLine(cust);
                            Console.WriteLine("-----------------");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            return MenuType.SearchCustomerMenu;
                        }
                    }
                        Console.WriteLine("Customer Not Found!");
                        Console.ReadLine();
                        return MenuType.SearchCustomerMenu;
                case "3":
                Console.WriteLine("Please Enter Customer Name:");
                    string name  = Console.ReadLine();
                    foreach (Customer cust in customers)
                    {
                        if (name == cust.Name){
                            Console.WriteLine("Customer Found!");
                            Console.WriteLine("-----------------");
                            Console.WriteLine(cust);
                            Console.WriteLine("-----------------");
                            Console.WriteLine("Press ENTER to continue");
                            Console.ReadLine();
                            return MenuType.SearchCustomerMenu;
                        }
                    }
                        Console.WriteLine("Customer Not Found!");
                        Console.ReadLine();
                        return MenuType.SearchCustomerMenu;
                    
                default:
                    return MenuType.SearchCustomerMenu;
            }
        }
    }
}