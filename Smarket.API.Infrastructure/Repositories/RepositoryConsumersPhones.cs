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
    public class RepositoryConsumersPhones : RepositoryBase<ConsumersPhones>, IRepositoryConsumersPhones
    {
        private readonly SmarketContext _context;

        public RepositoryConsumersPhones(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        //public ConsumersPhones AddConsumersPhones(Guid userId, Guid phoneId)
        //{
        //    _context.ConsumersPhones.Add(new ConsumersPhones { UserId = userId, PhoneId = phoneId });

        //    return new ConsumersPhones { UserId = userId, PhoneId = phoneId };

        //}
    }
}
