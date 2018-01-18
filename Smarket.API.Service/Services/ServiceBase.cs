using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Smarket.API.Domain.Interfaces.IServices;

namespace Smarket.API.Service.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity>, IDisposable
    {
        bool disposed = false;

        protected SmarketContext db;

        public ServiceBase()
        {
            db = new SmarketContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {

            }
        }

        public void Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public TEntity GetAsNoTracking(Expression<Func<TEntity, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAsNoTracking(Expression<Func<TEntity, bool>> expr)
        {
            throw new NotImplementedException();
        }
    }
}
