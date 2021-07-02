using System;

namespace StoreApp
{
    public class AddCustomerMenu : IMenu
    {
        public static Customer _newCustomer = new Customer();
        private ICustomerBL _customerBL;
        public AddCustomerMenu(ICustomerBL p_customerBL)
        {
            _customerBL = p_customerBL;
        }
        public void Menu()
        {
            Console.WriteLine("[4] Name" + _newCustomer.Name);
            Console.WriteLine("[3] Address"+ _newCustomer.Address);
            Console.WriteLine("[2] Email"+_newCustomer.Email);
            Console.WriteLine("[1] Add Customer");
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
                    _customerBL.AddCustomer(_newCustomer);
                    return MenuType.CustomerMenu;
                case "2":
                    _newCustomer.Email = Console.ReadLine();
                    return MenuType.CustomerMenu;
                case "3":
                    _newCustomer.Address = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                case "4":
                    _newCustomer.Name = Console.ReadLine();
                    return MenuType.AddCustomerMenu;
                default:
                    Console.WriteLine("Input was not correct");
                    Console.WriteLine("Press Enter to Continue");
                    Console.ReadLine();
                    return MenuType.AddCustomerMenu;
            }
        }
    }
}