using System;
using System.Collections.Generic;
namespace StoreApp
{
    public interface IInventory
    {
         List<LineItems> GetInventory(StoreFront p_storeFront);

         LineItems AddInventory(LineItems p_lineItems, int quantity);
    }
}