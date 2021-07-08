
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using DLEntities;
namespace StoreApp
{
    //This class abstracts what would be in the main and exports functionality to a "Factory".cs
    public class MenuFactory : IFactory
    {
        //Method is called within every case of the main switch, directing the user to the different interfaces
        public IMenu GetMenu(MenuType p_menu)
        {
            //get the configuration from our appsetting.json file
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DatabaseReference");

            DbContextOptions<FirstDatabaseContext> options = new DbContextOptionsBuilder<FirstDatabaseContext>()
                .UseSqlServer(connectionString)
                .Options;

            switch (p_menu)
            {
                case MenuType.MainMenu:
                    //brings users to the main menu -- instantiates that object
                    return new MainMenu();
                case MenuType.CustomerMenu:
                    //brings users to the customer menu -- instantiates that object
                    return new CustomerMenu();
                case MenuType.ShowCustomerMenu:
                    //brings users to the showcustomermenu, instantates that object and passes through a Customer and Repository object as nested parameters
                    return new ShowCustomerMenu(new CustomerBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.AddCustomerMenu:
                //brings users to the addcustomermenu, instantates that object and passes through a Customer and Repository object as nested parameters
                    return new AddCustomerMenu(new CustomerBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.SearchCustomerMenu:
                    return new SearchCustomerMenu(new CustomerBL(new Repository(new FirstDatabaseContext(options))));
                case MenuType.StoreFrontMenu:
                    return new StoreFrontMenu(); //needs a BL and DL
                case MenuType.StoreFrontInventoryMenu:
                    return new StoreFrontInventoryMenu();
                case MenuType.FindStoreFrontMenu:
                    return new FindStoreFrontMenu();
                case MenuType.ViewInventory:
                    return new ViewInventory();
                case MenuType.AddInventory:
                    return new AddInventory();
                case MenuType.StoreOrderHistory:
                    return new StoreOrderHistory();
                case MenuType.CustomerOrderHistory:
                    return new CustomerOrderHistory();
                case MenuType.CustomerFindStoreFrontMenu:
                    return new CustomerFindStoreFrontMenu();
                case MenuType.MakeAnOrder:
                    return new MakeAnOrder();
                case MenuType.CustomerValidation:
                    return new CustomerValidation(new CustomerBL(new Repository(new FirstDatabaseContext(options))));
                default:
                    return null;
            }
        }
    }
}