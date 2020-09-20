using Auction.DataAccess;
using System.Collections.Generic;

namespace Auction.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T newObject);
    }
}
