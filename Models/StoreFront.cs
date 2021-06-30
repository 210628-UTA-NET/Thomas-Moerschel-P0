using System;

namespace StoreApp
{
    public class StoreFront
    {
        protected string Name {get; set; }
        protected string Address {get; set; }
        protected string [] Inventory {get; set; }
        protected string [] ListofOrders {get; set; }
    }
}