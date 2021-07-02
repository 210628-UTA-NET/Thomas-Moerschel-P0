namespace StoreApp
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            switch (p_menu)
            {
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                case MenuType.ShowCustomerMenu:
                    return new ShowCustomerMenu(new CustomerBL(new Repository()));
                case MenuType.AddCustomerMenu:
                    return new AddCustomerMenu(new CustomerBL(new Repository()));
                default:
                    return null;
            }
        }
    }
}