using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IServices
{
    public interface IServiceBase<TEntity>
    {
        void                 Add(TEntity obj);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expr);
        TEntity              Get(Expression<Func<TEntity, bool>> expr);
        IEnumerable<TEntity> GetAll();
        void                 Update(TEntity obj);
        void                 SaveChanges();
        void                 Remove(TEntity obj);
        TEntity              GetAsNoTracking(Expression<Func<TEntity, bool>> expr);
        IEnumerable<TEntity> FindAsNoTracking(Expression<Func<TEntity, bool>> expr);
    }
}
