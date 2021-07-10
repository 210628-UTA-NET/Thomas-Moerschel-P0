using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class ManagementFindStoreFrontMenu : IMenu
    {
        private IStoreFrontBL _storeFrontBL;
        public ManagementFindStoreFrontMenu(IStoreFrontBL p_storeFrontBL){
            _storeFrontBL = p_storeFrontBL;
        }
        //Create StoreFront Object with Location Parameters based on what the user chooses
        public void Menu()
        {
           List<StoreFront> storeFronts = _storeFrontBL.GetAllStoreFronts();
            Console.WriteLine("Please choose the store location");
            Console.WriteLine("Choose from the following or type the city of your shop!");
            int count = 1;
            foreach (StoreFront store in storeFronts)
            {
                Console.WriteLine("[" + count + "] " + store.Address);
                count++;
            }
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            StoreFrontMenu location = new StoreFrontMenu();
            List<StoreFront> storeFronts = _storeFrontBL.GetAllStoreFronts();
            string userInput = Console.ReadLine();
            switch (userInput.ToLower())
            {
                case "0":
                    return MenuType.MainMenu;
                case "atlanta" or "atlanta's" or "atlantas" or "1":
                    location.storeLocation(storeFronts[0]);
                    return MenuType.StoreFrontMenu;
                case "gainesville" or "gainesville's" or "gainesvilles" or "2":
                    location.storeLocation(storeFronts[1]);
                    return MenuType.StoreFrontMenu;
                case "fort myers" or "fort myers'" or "fortmyers" or "fortmyers'" or "3":
                    location.storeLocation(storeFronts[2]);
                    return MenuType.StoreFrontMenu;
                default:
                    return MenuType.ManagementFindStoreFrontMenu;
            }
        }
    }
}