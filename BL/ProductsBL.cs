using System;
using System.Collections.Generic;
using StoreAppDL;
using StoreAppModels;

namespace StoreAppBL
{
    public class ProductsBL : IProductsBL
    {
        private IRepository _repo;
        public ProductsBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<Products> GetProducts(StoreFront p_storeFront)
        {
            return _repo.GetProducts(p_storeFront);
        }
    }
}