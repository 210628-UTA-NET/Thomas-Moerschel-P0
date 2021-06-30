using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            ICustomers UI = new MainMenu();
            bool repeat = true;
            string currentSelection = "MainMenu";

            List<Customer> CustomerList = new List<Customer>();

            while (repeat){

                
                UI.Menu();
                currentSelection = UI.UserInput;

                switch (currentSelection)
                {
                    case "MainMenu":
                        break;
                    case "anotherCustomer":
                        Console.WriteLine("Please input name:");
                        string _name = Console.ReadLine();
                        Console.WriteLine("Please input address:");
                        string _address = Console.ReadLine();
                        Console.WriteLine("Please input email:");
                        string _email = Console.ReadLine();
                        
                        CustomerList.Add(new Customer{Name = _name, Address = _address, Email = _email});
                        break;
                    case "customerList":
                        int count=1;
                        foreach (Customer person in CustomerList)
                        {
                            Console.WriteLine("Customer Number: " + count);
                            Console.WriteLine($"Name: {person.Name} \nAddress: {person.Address} \nEmail:  {person.Email}");
                            Console.WriteLine("______________________");
                            count++;
                        }
                        break;
                    case "Exit":
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