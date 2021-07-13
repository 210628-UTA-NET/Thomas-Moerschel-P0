using System;
using System.Collections.Generic;
using StoreAppDL;
using StoreAppModels;

namespace StoreAppBL
{
    public class OrderBL : IOrderBL
    {
        private IRepository _repo;
        public OrderBL(IRepository p_repo){
            _repo = p_repo;
        }
        public Orders AddOrder(StoreFront p_storeFront, Customer p_customer, Orders p_order)
        {
            return _repo.AddOrder(p_storeFront, p_customer, p_order);
        }

        public List<Orders> GetOrders(StoreFront p_storeFront)
        {
            return _repo.GetOrders(p_storeFront);
        }

        public List<Orders> GetOrders(Customer p_customer)
        {
            return _repo.GetOrders(p_customer);
        }
    }
}