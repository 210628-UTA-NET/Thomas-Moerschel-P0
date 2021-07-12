using System;
using System.Collections.Generic;
namespace StoreApp
{
    public interface IProductsBL
    {
        List <Products> GetProducts(StoreFront p_storeFront);


    }
}