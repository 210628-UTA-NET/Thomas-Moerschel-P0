
namespace StoreApp
{
    //It is best practice to use an enum within an interface for switch statments rather than a string
  public enum MenuType
    {
        MainMenu,
        CustomerMenu,
        ShowCustomerMenu,
        AddCustomerMenu,
        SearchCustomerMenu,
        Exit
    }
    
    public interface IMenu
    {
        void Menu();

        MenuType UserInput();
    }
}
