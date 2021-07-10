using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class CustomerFindStoreFrontMenu : IMenu
    {
        private IStoreFrontBL _storeFrontBL;
        public CustomerFindStoreFrontMenu(IStoreFrontBL p_storeFrontBL){
            _storeFrontBL = p_storeFrontBL;
        }
        
        public void Menu()
        {
            List<StoreFront> storeFronts = _storeFrontBL.GetAllStoreFronts();
            Console.WriteLine("Please choose the store location");
            Console.WriteLine("Choose from the following or type the city of your shop!");
            int count = 1;
            foreach (StoreFront store in storeFronts)
            {
                Console.WriteLine("[" + count + "]" + store.Address);
                count++;
            }
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.CustomerValidation;
                default:
                    return MenuType.CustomerFindStoreFrontMenu;
            }
        }
    }
}