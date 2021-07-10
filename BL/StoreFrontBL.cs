using System.Collections.Generic;

namespace StoreApp
{
    public class StoreFrontBL : IStoreFrontBL
    {
        private IRepository _repo;
        public StoreFrontBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<StoreFront> GetAllStoreFronts()
        {
            return _repo.GetAllStoreFronts();
        }

        public StoreFront GetInventory(StoreFront p_storeFront)
        {
            throw new System.NotImplementedException();
        }
    }
}