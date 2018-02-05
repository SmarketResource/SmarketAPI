using AutoMapper;
using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryMarket : RepositoryBase<Market>, IRepositoryMarket
    {

        private readonly SmarketContext _context;

        public RepositoryMarket(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public Market AddMarket(Market market)
        {
            _context.Market.Add(market);

            return market;
        }

        public MarketReturn GetMarkets()
        {
            var market = _context.Market.ToList();

            var returnModel = new MarketReturn { Markets = Mapper.Map<List<Market>, List<MarketModel>>(market) };

            return returnModel;
        }
    }
}
