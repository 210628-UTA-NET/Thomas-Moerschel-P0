using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using DLEntities;

namespace StoreApp
{
    
    public class Repository : IRepository
    {
        private DLEntities.FirstDatabaseContext _context;
        public Repository(DLEntities.FirstDatabaseContext p_context)
        {
            _context = p_context;
        }
        
        
        
        //Called within the BL from _rep, a repository field variable, takes in customer object
        public Customer AddCustomer(Customer p_customer)
        {
            //instantiates a list of customer to the GetAllCustomers() method below where the JSON file is read and committed to the list
            //List<Customer> listOfCustomers = this.GetAllCustomers();
            //After adding the preexisting json list, add the next object (p_customer) and rewrite JSON file 
            //listOfCustomers.Add(p_customer);
            //serializes the list of customers and sets it equal to the _jsonString
            //_jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{WriteIndented = true});
            //Writes the _jsonString to _filePath
            //File.WriteAllText(_filePath, _jsonString);
            //returns the customer object
            //return p_customer;
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            return _context.Customers.Select(
                cust =>
                    new Customer()
                    {
                        Id = cust.Id,
                        Name = cust.CustomerName,
                        Address = cust.CustomerAddress,
                        Email = cust.CustomerEmail
                    }
            ).ToList();
        }

        public Customer GetCustomer(Customer p_customer)
        {
            throw new NotImplementedException();
        }
    }
}
