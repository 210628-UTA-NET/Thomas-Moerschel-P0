using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface IOrderBL
    {
         List<Orders> GetOrders(StoreFront p_storeFront);
         List<Orders> GetOrders(Customer p_customer);
         Orders AddOrder(StoreFront p_storeFront, Customer p_customer, Orders order);
    }
}