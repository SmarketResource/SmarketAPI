using Smarket.API.Model.CommomModels;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceLot
    {

        List<LotModel> GetLots();

        LotReturn GetLotById(Guid id);

        LotReturn GetLotByDescription(string description);

        LotReturn GetLotsByMarket(Guid marketId);

        LotReturn GetLotsByProduct(Guid productId);

        BaseReturn SaveLot(Lots newLot);

    }
}
