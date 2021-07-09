using System;
using System.Collections.Generic;

#nullable disable

namespace DLEntities
{
    public partial class Order
    {
        public string OrderLocation { get; set; }
        public int? OrderPrice { get; set; }
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? StoreId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StoreFront Store { get; set; }
    }
}
