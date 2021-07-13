
namespace StoreAppUI
{
    //It is best practice to use an enum within an interface for switch statments rather than a string
  public enum MenuType
    {
        MainMenu,
        CustomerMenu,
        ShowCustomerMenu,
        AddCustomerMenu,
        SearchCustomerMenu,
        StoreOrderHistory,
        StoreFrontMenu,
        ManagementFindStoreFrontMenu,
        StoreFrontInventoryMenu,
        AddInventory,
        ViewInventory,
        CustomerOrderHistory,
        CustomerFindStoreFrontMenu,
        MakeAnOrder,
        CustomerValidation,
        CustomerCheckout,
        PurchaseConfirmation,
        SearchCustomerOrderHistory,
        ManagerValidation,
        AdministratorMenu,
        Exit
    }
    
    public interface IMenu
    {
        void Menu();

        MenuType UserInput();
    }
}
