namespace StoreAppWebUI.Models
{
    public class ProductsVM
    {
        public ProductsVM()
        { }
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string Name {get; set; }
        public double Price {get; set; }
        public string Category {get; set; }
    }
}