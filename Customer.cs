using System;

namespace StoreApp
{
    class Customer
    {
        protected string Name {get; set; }
        protected string Address {get; set; }
        protected string Email {get; set; }
        protected string [] ListofOrders {get; set; }

        static void Main(string[] args)
        {

            Console.WriteLine("Hello World! now change");
        }
    }
}
