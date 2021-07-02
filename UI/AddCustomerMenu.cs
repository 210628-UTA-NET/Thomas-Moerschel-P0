using System;

namespace StoreApp
{
    public class AddCustomerMenu : IMenu
    {   
        //creates static instance of Customer object
        public static Customer _newCustomer = new Customer();
        // Creates _IcustomerBL Interface Type 
        private ICustomerBL _customerBL;
        //AddCustomerMenu called by MenuFactory stating: new AddCustomerMenu(new CustomerBL(new Repository()));
        public AddCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("[4] Name: " + _newCustomer.Name);
            Console.WriteLine("[3] Address: "+ _newCustomer.Address);
            Console.WriteLine("[2] Email: "+_newCustomer.Email);
            Console.WriteLine("[1] Add Customer");
            Console.WriteLine("[0] Go Back");
        }
        //called by the main to retrieve user input for the AddCustomer Functionality
        public MenuType UserInput()
        {

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    //returns MenuType.CustomerMenu to the main program
                    return MenuType.CustomerMenu;
                case "1":
                    //adds _newCustomer to the _customerBL after case 2,3 and 4 have executed
                    _customerBL.AddCustomer(_newCustomer);
                    //clears the template to add a new customer after it is admitted
                    _newCustomer.Name = "";
                    _newCustomer.Address = "";
                    _newCustomer.Email = "";
                    //returns the menu type to the main that dictates to return to the Add or retrieve customer menu
                    return MenuType.CustomerMenu;
                case "2":
                    Console.WriteLine("Customer Email:");
                    //changes _newCustomer Email object parameter to user input
                    _newCustomer.Email = Console.ReadLine();
                    //returns menu type to the main that dictates to remain within this addCustomer menu
                    return MenuType.AddCustomerMenu;
                case "3":
                    Console.WriteLine("Customer Address:");
                    //changes _new Customer Address object parameter to user input
                    _newCustomer.Address = Console.ReadLine();
                    //returns menu type to the main that dictates to remain within this addCustomer menu
                    return MenuType.AddCustomerMenu;
                case "4":
                    Console.WriteLine("Customer Name:");
                    //changes _newCustomer Name object parameter to user input
                    _newCustomer.Name = Console.ReadLine();
                    //returns menu type to the main that dictates to remain within this addCustomer menu
                    return MenuType.AddCustomerMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    //returns menu type to the main that dictates to remain within this addCustomer menu
                    return MenuType.AddCustomerMenu;
            }
        }
    }
}