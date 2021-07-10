using System;
using System.Collections.Generic;

namespace StoreApp
{
    public interface ICustomerBL
    {
         List <Customer> GetAllCustomers();

         Customer AddCustomer(Customer p_customer);

         Customer GetCustomer(Customer p_customer);
    }
}