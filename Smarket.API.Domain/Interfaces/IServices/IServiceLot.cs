using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceLot
    {

        LotReturn GetLots();

        LotReturn GetLotById(Guid id);

        LotReturn GetLotByDescription(string description);

        LotReturn GetLotsByMarket(Guid marketId);

        LotReturn GetLotsByProduct(Guid productId);

        BaseReturn SaveLot(Lots newLot);

    }
}
