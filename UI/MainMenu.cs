using System;

namespace StoreApp
{
    public class MainMenu : ICustomers
    {

        public void Menu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[0] Add another customer");
            Console.WriteLine("[1] List all Customers");
            Console.WriteLine("[2] Exit");

        }

        string ICustomers.UserInput()
        {
            throw new NotImplementedException();
        }

        public string UserInput
        {
            get
            {
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        return "anotherCustomer";
                    case "1":
                        return "customerList";
                    case "2":
                        return "Exit";
                    default:
                        return "Improper Input";
                }
            }
        }
    }
}