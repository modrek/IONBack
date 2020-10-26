using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IONSolution.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Add entiry
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        #endregion Add entiry

        #region Update entiry
        void Update(TEntity entity);

        #endregion Add entiry

        #region Remove Entity
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void RemoveAll();
        #endregion

        #region Find entity
        TEntity Get(string Id);
        #endregion

        bool SaveChanges();


       

    }
}
