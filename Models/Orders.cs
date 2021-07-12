using System;

namespace StoreApp
{
    public class Orders
    {
        public string [] OrderLineItems {get; set; }
        public int StoreId {get; set; }
        public int CustomerId { get; set; }
        public double Price {get; set; }

        public override string ToString()
        {
            return $"Store ID: {StoreId} Customer ID: {CustomerId} Order Price: ${Price}";
        }
    }

}