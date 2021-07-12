using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class InventoryBL : IInventory
    {   
        private IRepository _repo;
        public InventoryBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public LineItems AddInventory(LineItems p_lineItems, int quantity)
        {
            return _repo.AddInventory(p_lineItems, quantity);
        }

        public List<LineItems> GetInventory(StoreFront p_storeFront)
        {
            return _repo.GetInventory(p_storeFront);
        }
    }
}