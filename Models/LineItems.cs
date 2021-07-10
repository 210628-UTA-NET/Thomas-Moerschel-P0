using System;

namespace StoreApp
{
    public class LineItems
    {
        public int storeId { get; set; }
        public int Id { get; set; }
        public string Product {get; set; }
        public int Quantity {get; set; }
        
        public override string ToString()
        {
        return $"Inventory Id: {Id}\nProduct: {Product}\nQuantity: {Quantity}";
        }
    }
}