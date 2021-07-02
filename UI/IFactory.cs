namespace StoreApp
{
    public interface IFactory
    {
         IMenu GetMenu(MenuType p_Menu);
    }
}