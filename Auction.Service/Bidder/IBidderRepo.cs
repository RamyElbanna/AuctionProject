using Auction.DataAccess;
using System.Collections.Generic;

namespace Auction.Service
{
    public interface IBidderRepo
    {
            IEnumerable<Bidder> GetAll();
            Bidder GetById(int id);
            int Add(Bidder newItem);
    }
}
