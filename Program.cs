using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Welcome to the training project where we will get your information.");

            ICustomers UI = new MainMenu();
            bool repeat = true;
            string currentSelection = "MainMenu";

            List<Customer> CustomerList = new List<Customer>();

            while (repeat){

                
                UI.Menu();
                currentSelection = UI.UserInput();
                Console.WriteLine(currentSelection);

                switch (currentSelection)
                {
                    case "MainMenu":
                        break;
                    case "anotherCustomer":
                        Console.WriteLine("this worked");
                        Console.WriteLine("Please input name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Please input address:");
                        string address = Console.ReadLine();
                        Console.WriteLine("Please input email:");
                        string email = Console.ReadLine();
                        
                        CustomerList.Add(new Customer(name, address, email));
                        Console.WriteLine("Success" + CustomerList.Count);
                        break;
                    case "Exit":
                        Console.WriteLine("exit worked why arent the others");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Improper Input");
                        break;
                }
            }
        }
    }

}    
