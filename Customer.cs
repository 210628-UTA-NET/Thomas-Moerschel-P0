using System;

namespace StoreApp
{
    class Customer
    {
        string name;
        string address;
        string email;

        
        public Customer(string name, string address, string email){
            this.name = name;
            this.address = address;
            this.email = email;
        }
        public string Name {get; set; }
        public string Address {get; set; } 
        public string Email {get; set; }
        public object [] ListofOrders {get; set; }

        }
  
}
