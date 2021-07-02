using System;

namespace StoreApp
{
    public class MainMenu : IMenu
    {

        public void Menu()
        {
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Go to Customer Menu");
            Console.WriteLine("[0] Exit");

        }

       

        public MenuType UserInput ()
        {
            
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        return MenuType.Exit;
                    case "1":
                        return MenuType.CustomerMenu;
                    default:
                        Console.WriteLine("Input was not correct");
                        Console.WriteLine("Please press ENTER to continue");
                        Console.ReadLine();
                        return MenuType.MainMenu;
                }
            
        }
    }
}