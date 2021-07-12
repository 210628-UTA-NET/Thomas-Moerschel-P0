using System;
namespace StoreApp
{
    public class PurchaseConfirmation : IMenu
    {
        public static Customer customerPurchase = new Customer();
        public void customerInformation (Customer p_cusotmer)
        {
            customerPurchase = p_cusotmer;
        }
        public void Menu()
        {
            Console.WriteLine("Thank you " + customerPurchase.Name + " for your purchase!");
            Console.WriteLine("A Confirmation Email has been sent to: " + customerPurchase.Email);
            Console.WriteLine("The package will be delivered to:\n" + customerPurchase.Address);
            Console.WriteLine("[0] Return to Main Menu");
        }

        public MenuType UserInput()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return MenuType.MainMenu;
                default:
                    return MenuType.PurchaseConfirmation;
            }
            
        }
    }
}