using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace StoreApp
{
    //manages the submission of objects to a .json file
    public class Repository : IRepository
    {
        //denotes file path of where the .json file is located 
        private const string _filePath = "./../DL/Database/Customer.json";
        //creates a private string that is Serializes the list of customers
        private string _jsonString;
        
        //Called within the BL from _rep, a repository field variable, takes in customer object
        public Customer AddCustomer(Customer p_customer)
        {
            //instantiates a list of customer to the GetAllCustomers() method below where the JSON file is read and committed to the list
            List<Customer> listOfCustomers = this.GetAllCustomers();
            //After adding the preexisting json list, add the next object (p_customer) and rewrite JSON file 
            listOfCustomers.Add(p_customer);
            //serializes the list of customers and sets it equal to the _jsonString
            _jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{WriteIndented = true});
            //Writes the _jsonString to _filePath
            File.WriteAllText(_filePath, _jsonString);
            //returns the customer object
            return p_customer;
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                //reads test within the json file at the _filepath and saves it to the private _jsonString
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
