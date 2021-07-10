using System;
using System.Collections.Generic;

#nullable disable

namespace DLEntities
{
    public partial class LineItem
    {
        public int LineItemId { get; set; }
        public string LineItemIdName { get; set; }
        public int? LineItemQuantity { get; set; }
        public int? StoreId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual StoreFront Store { get; set; }
    }
}
