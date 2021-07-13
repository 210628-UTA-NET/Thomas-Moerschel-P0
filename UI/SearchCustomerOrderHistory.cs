using System;
using StoreAppBL;
using StoreAppModels;

namespace StoreAppUI
{
    public class SearchCustomerOrderHistory : IMenu
    {
        public static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        public SearchCustomerOrderHistory(){}
        public SearchCustomerOrderHistory(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            SearchCustomerMenu newCustomerMenu = new SearchCustomerMenu();
            newCustomerMenu.Menu();
        }

        public MenuType UserInput()
        {
            SearchCustomerMenu newCustomerMenu = new SearchCustomerMenu();
            CustomerOrderHistory newOrderHistory = new CustomerOrderHistory();
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    Console.WriteLine("Please Enter Customer Email:");
                    Console.WriteLine("-------------------------------");

                    _newCustomer.Email = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("===================");
                        Console.WriteLine("Customer Not Found!");
                        Console.WriteLine("===================");
                        Console.ReadLine();
                        return MenuType.SearchCustomerOrderHistory;
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Address = _customerBL.GetCustomer(_newCustomer).Address;
                        newOrderHistory.customerInformation(_newCustomer);
                        _newCustomer = new Customer();
                    }
                    return MenuType.CustomerOrderHistory;
                    
                case "2":
                    Console.WriteLine("Please Enter Customer Address:");
                    Console.WriteLine("-------------------------------");
                    _newCustomer.Address = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("===================");
                        Console.WriteLine("Customer Not Found!");
                        Console.WriteLine("===================");
                        Console.ReadLine();
                        return MenuType.SearchCustomerOrderHistory;
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Email = _customerBL.GetCustomer(_newCustomer).Email;
                        newOrderHistory.customerInformation(_newCustomer);
                        _newCustomer = new Customer();
                    }
                    return MenuType.CustomerOrderHistory;
                case "3":
                Console.WriteLine("Please Enter Customer Name:");
                Console.WriteLine("-------------------------------");
                    _newCustomer.Name  = Console.ReadLine();
                    _newCustomer.Name =_customerBL.GetCustomer(_newCustomer).Name;

                    if (_newCustomer.Name == "Invalid Entry")
                    {
                        Console.WriteLine("===================");
                        Console.WriteLine("Customer Not Found!");
                        Console.WriteLine("===================");
                        Console.ReadLine();
                        return MenuType.SearchCustomerOrderHistory;
                    }
                    else
                    {
                        _newCustomer.Id = _customerBL.GetCustomer(_newCustomer).Id;
                        _newCustomer.Address = _customerBL.GetCustomer(_newCustomer).Address;
                        _newCustomer.Email = _customerBL.GetCustomer(_newCustomer).Email;
                        newOrderHistory.customerInformation(_newCustomer);
                        _newCustomer = new Customer();
                    }
                    return MenuType.CustomerOrderHistory;
                    
                default:
                    return MenuType.SearchCustomerOrderHistory;
            }
        }
    }
}