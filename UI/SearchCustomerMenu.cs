using System;
using System.Collections.Generic;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class SearchCustomerMenu : IMenu
    {
        public static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        public SearchCustomerMenu(){}
        public SearchCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("How would you like to search?");
            Console.WriteLine("[3] Search by Name");
            Console.WriteLine("[2] Search by Address");
            Console.WriteLine("[1] Search by Email");
            Console.WriteLine("==============================");
            Console.WriteLine("[0] Go Back");
            
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    Console.WriteLine("Please Enter Customer Email:");

                    _newCustomer.Email = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("Customer Not Found!");
                        Console.ReadLine();
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Address = _customerBL.GetCustomer(_newCustomer).Address;
                        Console.WriteLine(_newCustomer);
                        Console.ReadLine();
                        _newCustomer = new Customer();
                    }
                    return MenuType.SearchCustomerMenu;
                    
                case "2":
                    Console.WriteLine("Please Enter Customer Address:");
                    _newCustomer.Address = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("Customer Not Found!");
                        Console.ReadLine();
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Email = _customerBL.GetCustomer(_newCustomer).Email;
                        Console.WriteLine(_newCustomer);
                        Console.ReadLine();
                        _newCustomer = new Customer();
                    }
                    return MenuType.SearchCustomerMenu;
                case "3":
                Console.WriteLine("Please Enter Customer Name:");
                    _newCustomer.Name  = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("Customer Not Found!");
                        Console.ReadLine();
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Address = _customerBL.GetCustomer(_newCustomer).Address;
                        _newCustomer.Email = _customerBL.GetCustomer(_newCustomer).Email;
                        Console.WriteLine(_newCustomer);
                        Console.ReadLine();
                        _newCustomer = new Customer();
                    }
                    return MenuType.SearchCustomerMenu;
                    
                default:
                    return MenuType.SearchCustomerMenu;
            }
        }
    }
}