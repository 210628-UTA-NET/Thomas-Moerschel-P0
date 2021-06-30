using System;

namespace StoreApp
{
    public class MainMenu : ICustomers
    {

        public void Menu()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[0] Add another customer");
            Console.WriteLine("[1] Exit");

        }
       
        public string UserInput()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "anotherCustomer";
                case "1":
                    return "Exit";
                default:
                    return "Improper Input";
            }
        }
    }
}