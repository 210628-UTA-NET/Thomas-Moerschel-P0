using System;
using System.Collections.Generic;

namespace StoreApp
{
    public interface ICustomerBL
    {
         List <Customer> GetAllCustomers();

         Customer AddCustomer(Customer p_customer);
    }
}