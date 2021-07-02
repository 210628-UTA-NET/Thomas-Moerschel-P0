using System;

namespace StoreApp
{
    public class Customer
    {
        public string Name {get; set; }
        public string Address {get; set; } 
        public string Email {get; set; }
        public object [] ListofOrders {get; set; }

        


        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nEmail: {Email}\n";
        }

        }
  
}
