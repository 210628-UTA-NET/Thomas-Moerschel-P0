using System.Collections.Generic;
using System;
using StoreApp;

namespace StoreApp
{
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        //Referenced by the ShowCustomerMenu(...) and AddCustomerMenu(...) within the MenuFactory takes in a IRepository variable (_repo)
        public CustomerBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        //Irepository field variable calls the repository AddCustomer() method which inputs an object to be added to the collection
        public Customer AddCustomer(Customer p_customer)
        {
            return _repo.AddCustomer(p_customer);
        }
        //Irepository field variable that calls the GetAllCustoms() method defined within the Repository class
        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customer GetCustomer(Customer p_customer)
        {
            return _repo.GetCustomer(p_customer);
        }
    }
}
