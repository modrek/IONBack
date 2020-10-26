using IONSolution.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONSolution.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private IONDBContext _context;

        public Repository(IONDBContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public bool SaveChanges()
        {

            return (_context.SaveChanges() > 0);

        }

        public TEntity Get(string Id)
        {
            var sss = _context.Users.Find(Id);
            return _context.Set<TEntity>().Find(Id);
        }

     
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveAll()
        {
            _context.Set<TEntity>().RemoveRange(_context.Set<TEntity>());
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            var entry = _context.Entry(entity);
            
        }

      
        public long GetCount()
        {
            return _context.Set<TEntity>().Count();
        }
    }
}
