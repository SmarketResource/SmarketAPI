using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Smarket.API.Model.Context;
using System.Data.Entity;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IContext;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {

        private readonly SmarketContext _context;

        public RepositoryBase(IDbContext context)
        {
            if (context == null) throw new Exception("Context can not be null");

            _context = (SmarketContext)context;
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public bool Any(Expression<Func<TEntity, bool>> expr)
        {
            return _context.Set<TEntity>().Any(expr);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expr)
        {
            return _context.Set<TEntity>().Where(expr);
        }

        public IEnumerable<TEntity> FindAsNoTracking(Expression<Func<TEntity, bool>> expr)
        {
            return _context.Set<TEntity>().Where(expr).AsNoTracking();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expr)
        {
            return _context.Set<TEntity>().FirstOrDefault(expr);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetAsNoTracking(Expression<Func<TEntity, bool>> expr)
        {
            return _context.Set<TEntity>().Where(expr).AsNoTracking().FirstOrDefault();
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
