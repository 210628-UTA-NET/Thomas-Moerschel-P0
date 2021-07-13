using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppDL

{
    public interface IRepository
    {
         List<Customer> GetAllCustomers();

         Customer GetCustomer(Customer p_customer);

         Customer AddCustomer(Customer p_customer);
         List<StoreFront> GetAllStoreFronts();
         LineItems AddInventory(LineItems p_lineItems, int quantity);
         List<LineItems> GetInventory(StoreFront p_storeFront);
         List<Products> GetProducts(StoreFront p_storeFront);
         List<Orders> GetOrders(StoreFront p_storeFront);
         List<Orders> GetOrders(Customer p_customer);
         Orders AddOrder(StoreFront p_storeFront, Customer p_customer, Orders p_order);

        

    }
}