using Auction.DataAccess;
using Auction.Repository;
using System.Collections.Generic;

namespace Auction.Service
{
    public class AuctionDetailsRepo : IAuctionDetailsRepo
    {
        private IRepository<AuctionWinnerDetails> _repository;
        // consturctor
        public AuctionDetailsRepo(IRepository<AuctionWinnerDetails> repository)
        {
            _repository = repository;
        }

        public int Add(AuctionWinnerDetails newItem)
        {
            return _repository.Add(newItem);
        }

        public IEnumerable<AuctionWinnerDetails> GetAll()
        {
            return _repository.GetAll();
        }

        public AuctionWinnerDetails GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
