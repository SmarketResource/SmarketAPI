using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryMarket : IRepositoryBase<Market>
    {
        MarketReturn GetMarkets();

        Market AddMarket(Market market);

    }
}
