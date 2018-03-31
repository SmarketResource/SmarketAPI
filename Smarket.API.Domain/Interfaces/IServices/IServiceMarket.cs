using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceMarket
    {
        MarketReturn GetMarkets();

        BaseReturn SaveMarket (Market market);
    }
}
