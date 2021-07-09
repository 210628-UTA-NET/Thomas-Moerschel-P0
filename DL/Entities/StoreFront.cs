using System;
using System.Collections.Generic;

#nullable disable

namespace DLEntities
{
    public partial class StoreFront
    {
        public StoreFront()
        {
            Orders = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
