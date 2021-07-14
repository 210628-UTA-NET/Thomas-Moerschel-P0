using System;

namespace StoreAppModels
{
    public class StoreFront
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public string Address {get; set; }
        public string [] Inventory {get; set; }
        public string [] ListofOrders {get; set; }
        
        public override string ToString()
        {
            return $"Name: {Name},\n Address: {Address}";
        }
    }

}