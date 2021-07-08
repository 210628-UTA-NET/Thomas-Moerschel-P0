using System; 


namespace StoreApp
{
    public class FindStoreFrontMenu : IMenu
    {
        StoreFrontMenu location = new StoreFrontMenu();
        public object[] storeFronts = {3};
        StoreFront store1 = new StoreFront("Atlanta's Luxery Clothing Outlet", "Atlanta, Georgia");
        StoreFront store2 = new StoreFront("Fort Myers' Luxery Clothing Outlet", "Fort Myers, Florida");
        StoreFront store3 = new StoreFront("Gainesville's Luxery Cloting Outlet", "Gainesville, Florida");
        //Create StoreFront Object with Location Parameters based on what the user chooses
        public void Menu()
        {
            object[] storeFronts = {store1, store2, store3};
            Console.WriteLine("Welcome to the Store Front Menu!");
            Console.WriteLine("Choose from the following or type the city of your shop!");
            Console.WriteLine(string.Format("[3] {0}\n[2] {1}\n[1] {2}", store1, store2, store3));
            Console.WriteLine("[0] Go Back");
        }

        public MenuType UserInput()
        {
            StoreFrontMenu location = new StoreFrontMenu();
            string userInput = Console.ReadLine();
            switch (userInput.ToLower())
            {
                case "0":
                    return MenuType.MainMenu;
                case "atlanta" or "atlanta's" or "atlantas" or "3":
                    location.storeLocation(store1);
                    return MenuType.StoreFrontMenu;
                case "fort myers" or "fort myers'" or "fortmyers" or "fortmyers'" or "2":
                    location.storeLocation(store2);
                    return MenuType.StoreFrontMenu;
                case "gainesville" or "gainesville's" or "gainesvilles" or "1":
                    location.storeLocation(store3);
                    return MenuType.StoreFrontMenu;
                default:
                    return MenuType.FindStoreFrontMenu;
            }
        }
    }
}