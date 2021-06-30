using System;
using System.Collections.Generic;
namespace StoreApp

{
    public interface IRepository
    {
         List<Customer> GetAllCustomers();

         Customer GetCustomer(Customer p_customer);

         Customer AddCustomer(Customer p_customer);
    }
}