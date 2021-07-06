using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class ShowCustomerMenu : IMenu
    {
        //creates _customerBl of type interface: ICustomerBL
        private ICustomerBL _customerBL;
        //Called within MenuFactory and passes in BL and Repo as parameters: new ShowCustomerMenu(new CustomerBL(new Repository()))
        public ShowCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("List of Customers:");
            //instantiates a list of Customer of type ICustomerBL and calls the "GetAllCustomers" Method within the BL that retrieves information from the repository
            List <Customer> customers = _customerBL.GetAllCustomers();

            //loop through list of customers and print the Customer Object (capable via the toString override method)
            foreach (Customer cust in customers)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(cust);
                Console.WriteLine("-------------------");
            }
            Console.WriteLine("[0] Go Back");
            
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    //returns user to CustomerMenu based off of UserInput
                    return MenuType.CustomerMenu;
                default:
                    Console.WriteLine("Improper Input");
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    //Default notifies of Improper input then returns user to CustomerMenu
                    return MenuType.CustomerMenu;
            }
        }
    }
}