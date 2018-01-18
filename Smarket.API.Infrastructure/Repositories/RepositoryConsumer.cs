using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.Context;
using System;
using Smarket.API.Model.Returns;
using Smarket.API.Domain.Interfaces.IContext;
using System.Linq;
using Smarket.API.Model.CommomModels;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryConsumer : RepositoryBase<Consumers>, IRepositoryConsumer
    {
        private readonly SmarketContext _context;

        public RepositoryConsumer(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public Consumers AddConsumer(Consumers consumer)
        {
            _context.Consumers.Add(consumer);

            return consumer;
        }

        public ConsumerReturn GetConsumers()
        {
            var returnModel = new ConsumerReturn
            {
                Consumers = _context.Consumers.Select(c => new ConsumerModel
                {
                    UserId      = c.UserId,
                    Name        = c.Name,
                    LastName    = c.LastName,
                    Avatar      = c.Avatar
                }).ToList()
            };

            return returnModel;
        }
    }
}
