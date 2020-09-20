using Auction.DataAccess;
using Auction.Repository;
using System.Collections.Generic;

namespace Auction.Service
{
    public class BidderRepo : IBidderRepo
    {
        private IRepository<DataAccess.Bidder> _repository;
        // consturctor
        public BidderRepo(IRepository<Bidder> repository)
        {
            _repository = repository;
        }

        public int Add(Bidder newItem)
        {
            return _repository.Add(newItem);
        }

        public IEnumerable<Bidder> GetAll()
        {
            return _repository.GetAll();
        }

        public Bidder GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
