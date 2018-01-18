using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryLog : RepositoryBase<Logs>, IRepositoryLog
    {
        public readonly SmarketContext _context;

        public RepositoryLog(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public void AddLog(string message)
        {
            _context.Logs.Add(new Logs
            {
                LogId = Guid.NewGuid(),
                LogDate = DateTime.Now,
                Message = message
            });

            _context.SaveChanges();
        }
    }
}
