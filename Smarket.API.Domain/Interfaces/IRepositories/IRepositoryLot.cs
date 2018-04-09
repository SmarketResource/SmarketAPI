using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryLot : IRepositoryBase<Lots>
    {
        List<Lots> GetLots();

        LotReturn GetLotById(Guid id);

        LotReturn GetLotByDescription(string description);

        LotReturn GetLotsByMarket(Guid marketId);

        LotReturn GetLotsByProduct(Guid productId);

        Lots AddLot(Lots newLot);
    }
}
