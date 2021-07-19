using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface IInventoryBL
    {
         List<LineItems> GetInventory(StoreFront p_storeFront);
         LineItems AddInventory(LineItems p_lineItems, int quantity);
    }
}