using System;

namespace StoreApp
{
    public class Customer
    {
        public string Name {get; set; }
        public string Address {get; set; } 
        public string Email {get; set; }
        public object [] ListofOrders {get; set; }

        
        //overrides default string function allowing you to output object parameters:: otherwise you receive "namespace.class"

        public override string ToString()
        {
            return $"Name: {Name}\nAddress: {Address}\nEmail: {Email}\n";
        }

        }
  
}
