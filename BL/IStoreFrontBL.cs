using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface IStoreFrontBL
    {
         List <StoreFront> GetAllStoreFronts();
         StoreFront GetInventory(StoreFront p_storeFront);
    }
}