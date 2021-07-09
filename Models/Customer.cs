using System;

namespace StoreApp
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public string Address {get; set; } 
        public string Email {get; set; }
        public object [] ListofOrders {get; set; }

        
        //overrides default string function allowing you to output object parameters:: otherwise you receive "namespace.class"

        public override string ToString()
        {
            return $"Cusstomer ID: {Id}\nName: {Name}\nAddress: {Address}\nEmail: {Email}";
        }

        }
  
}
