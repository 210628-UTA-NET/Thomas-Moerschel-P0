namespace StoreAppWebUI.Models
{
    public class LineItemsVM
    {
        public LineItemsVM()
        { }
        public int storeId { get; set; }
        public int Id { get; set; }
        public string Product {get; set; }
        public int Quantity {get; set; }
    }
}