using Auction.DataAccess;
using Auction.Repository;
using System.Collections.Generic;

namespace Auction.Service
{
    public class ItemRepo : IItemRepo
    {
        private IRepository<Item> _repository;
        // consturctor
        public ItemRepo(IRepository<Item> repository)
        {
            _repository = repository;
        }

        public int Add(Item newItem)
        {
            return _repository.Add(newItem);
        }

        public IEnumerable<Item> GetAll()
        {
            return _repository.GetAll();
        }

        public Item GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
