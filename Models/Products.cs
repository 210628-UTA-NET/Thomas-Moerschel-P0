using System;

namespace StoreApp
{
    public class Products
    {
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public string Name {get; set; }
        public double Price {get; set; }
        public string Category {get; set; }

        public override string ToString()
        {
            return $"Product ID: {ProductId}\nProduct: {Name}\nCategory: {Category}\nPrice: ${Price} ";
        }
    }
}