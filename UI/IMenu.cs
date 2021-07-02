
namespace StoreApp
{
    public enum MenuType
    {
        MainMenu,
        CustomerMenu,
        ShowCustomerMenu,
        AddCustomerMenu,
        Exit
    }
    
    public interface IMenu
    {
        void Menu();

        MenuType UserInput();
    }
}
