using Auction.DataAccess;
using System.Collections.Generic;

namespace Auction.Service
{
    public interface IItemRepo
    {
        IEnumerable<Item> GetAll();
        Item GetById(int id);
        int Add(Item newItem);
    }
}
