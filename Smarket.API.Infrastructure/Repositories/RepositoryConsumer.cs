using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.Context;
using System;
using Smarket.API.Model.Returns;
using Smarket.API.Domain.Interfaces.IContext;
using System.Linq;
using Smarket.API.Model.CommomModels;
using AutoMapper;
using System.Collections.Generic;

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

            var consumers = _context.Consumers.Select(c => c).ToList();

            var returnModel = new ConsumerReturn{ Consumers = Mapper.Map<List<Consumers>, List<ConsumerModel>>(consumers) };

            return returnModel;
        }
    }
}
