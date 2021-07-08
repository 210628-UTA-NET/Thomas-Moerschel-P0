using System;
using System.Collections.Generic;
namespace StoreApp
{
    public interface IStoreFrontBL
    {
         List <StoreFront> GetAllStoreFronts();

         StoreFront GetInventory(StoreFront p_storeFront);

    }
}