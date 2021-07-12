using System;
using System.Collections.Generic;

#nullable disable

namespace DLEntities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public int? StoreId { get; set; }
    }
}
