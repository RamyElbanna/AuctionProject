
using Auction.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Auction.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity 
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _entity;

        // constructor
        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = _dbContext.Set<T>();
        }
        public int Add(T newObject)
        {
            _entity.Add(newObject);
            try
            {
                _dbContext.SaveChanges();
                return newObject.Id;
            }
            catch (System.Exception)
            {
                return 0;
            }

        }

        public IEnumerable<T> GetAll()
        {
            return _entity.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _entity.FirstOrDefault(e => e.Id == id);
        }
    }
}
