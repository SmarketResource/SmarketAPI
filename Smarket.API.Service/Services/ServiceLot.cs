using AutoMapper;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace Smarket.API.Service.Services
{
    public class ServiceLot : ServiceBase<Lots>, IServiceLot
    {
        private readonly IRepositoryLot _repositoryLot;

        public ServiceLot(IRepositoryLot repositoryLot)
        {
            _repositoryLot = repositoryLot;
        }

        public BaseReturn SaveLot(Lots newLot)
        {
            var returnModel = new BaseReturn();

            var lotExists = _repositoryLot.Get(s => s.Description.ToUpper() == newLot.Description.ToUpper() && s.MarketId == newLot.MarketId);

            if (lotExists == null)
            {
                using (var transaction = new TransactionScope())
                {

                    _repositoryLot.AddLot(newLot);

                    _repositoryLot.SaveChanges();

                    transaction.Complete();
                }

                returnModel.Message = GeneralMessagesEN.SaveLotSuccess;
            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.SaveLotAlreadyExists;
            }
            return returnModel;
        }

        public LotReturn GetLotByDescription(string description)
        {
            var returnModel = new LotReturn();

            returnModel = _repositoryLot.GetLotByDescription(description);

            return returnModel;
        }

        public LotReturn GetLotById(Guid id)
        {
            var returnModel = new LotReturn();

            returnModel = _repositoryLot.GetLotById(id);

            return returnModel;
        }

        public List<LotModel> GetLots()
        {
            List<LotModel> returnModel;

            returnModel = Mapper.Map<List<Lots>, List<LotModel>>(_repositoryLot.GetLots());

            return returnModel;
        }

        public LotReturn GetLotsByMarket(Guid marketId)
        {
            var returnModel = new LotReturn();

            returnModel = _repositoryLot.GetLotsByMarket(marketId);

            return returnModel;
        }

        public LotReturn GetLotsByProduct(Guid productId)
        {
            var returnModel = new LotReturn();

            returnModel = _repositoryLot.GetLotsByProduct(productId);

            return returnModel;
        }
    }
}
