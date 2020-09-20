using Auction.DataAccess;
using System.Collections.Generic;

namespace Auction.Service
{
    public interface IAuctionDetailsRepo
    {
        IEnumerable<AuctionWinnerDetails> GetAll();
        AuctionWinnerDetails GetById(int id);
        int Add(AuctionWinnerDetails newItem);
    }
}
