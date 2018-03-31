using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryLot : RepositoryBase<Lots>, IRepositoryLot
    {
        private readonly SmarketContext _context;

        public RepositoryLot(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public Lots AddLot(Lots newLot)
        {
            _context.Lots.Add(newLot);
            return newLot;
        }

        public LotReturn GetLotByDescription(string description)
        {
            var lots = _context.Lots.Where(p => p.Description == description).ToList();

            var returnModel = new LotReturn { Lots = Mapper.Map<List<Lots>, List<LotModel>>(lots) };

            return returnModel;
        }

        public LotReturn GetLotById(Guid id)
        {
            var lots = _context.Lots.Where(p => p.LotId == id).ToList();

            var returnModel = new LotReturn { Lots = Mapper.Map<List<Lots>, List<LotModel>>(lots) };

            return returnModel;
        }

        public LotReturn GetLots()
        {
            var lots = _context.Lots.ToList();

            var returnModel = new LotReturn { Lots = Mapper.Map<List<Lots>, List<LotModel>>(lots) };

            return returnModel;
        }

        public LotReturn GetLotsByMarket(Guid marketId)
        {
            var lots = _context.Lots.Where(p => p.MarketId == marketId).ToList();

            var returnModel = new LotReturn { Lots = Mapper.Map<List<Lots>, List<LotModel>>(lots) };

            return returnModel;
        }

        public LotReturn GetLotsByProduct(Guid productId)
        {
            var lots = _context.Lots.Where(p => p.ProductId == productId).ToList();

            var returnModel = new LotReturn { Lots = Mapper.Map<List<Lots>, List<LotModel>>(lots) };

            return returnModel;
        }

    }
}
