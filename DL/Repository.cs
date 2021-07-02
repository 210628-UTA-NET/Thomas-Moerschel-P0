using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StoreApp
{
    public class Repository : IRepository
    {
        private const string _filePath = "./../DL/Database/Customer.json";
        private string _jsonString;
        
        public Customer AddCustomer(Customer p_customer)
        {
            List<Customer> listOfCustomers = this.GetAllCustomers();
            listOfCustomers.Add(p_customer);

            _jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(_filePath, _jsonString);
            return p_customer;
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                _jsonString = File.ReadAllText(_filePath);
            }
            catch (System.Exception)
            {
                throw new Exception ("File path is invalid");
            }
                //This will return a list of Customer from the jsonString that it came from
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }

        public Customer GetCustomer(Customer p_customer)
        {
            throw new NotImplementedException();
        }
    }
}
