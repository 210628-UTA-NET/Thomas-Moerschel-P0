namespace StoreAppWebUI.Models
{
    public class OrdersVM
    {
        public OrdersVM()
        { }
        public int Id { get; set; }
        public int StoreId {get; set; }
        public int CustomerId { get; set; }
        public double Price {get; set; }

    }
}