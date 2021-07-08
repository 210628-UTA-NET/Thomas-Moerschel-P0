using System;
namespace StoreApp
{
    public class ViewInventory : IMenu
    {
        public void Menu()
        {
            Console.WriteLine("Inventory List");
            Console.WriteLine("--------------");
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return MenuType.StoreFrontInventoryMenu;
                default:
                    Console.WriteLine("Improper Input");
                    Console.WriteLine("Press ENTER to continue");
                    Console.ReadLine();
                    return MenuType.ViewInventory;
            }
        }
    }
}