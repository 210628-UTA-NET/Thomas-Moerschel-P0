using System;
using System.Collections.Generic;
using StoreAppModels;

namespace StoreAppBL
{
    public interface IProductsBL
    {
        List <Products> GetProducts(StoreFront p_storeFront);
    }
}