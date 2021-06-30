using System;

namespace StoreApp
{
    public class Orders
    {
        protected string [] OrderLineItems {get; set; }
        protected string Location {get; set; }
        protected double Price {get; set; }
    }
}