using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Smarket.API.Model.Context;
using System.Data.Entity;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IContext;
using System.Data.Entity.Validation;

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
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}
