using System; 

namespace StoreApp
{
    public class FindStoreFrontMenu : IMenu
    {
        //Create StoreFront Object with Location Parameters based on what the user chooses
        public void Menu()
        {
            Console.WriteLine("Welcome to the Store Front Menu!");
            Console.WriteLine("Search for a Store!");
            Console.WriteLine("*Display List of Store Locations*");
            Console.WriteLine("Temp: [1] StoreFront Found!");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.StoreFrontMenu;
                default:
                    return MenuType.FindStoreFrontMenu;
            }
        }
    }
}