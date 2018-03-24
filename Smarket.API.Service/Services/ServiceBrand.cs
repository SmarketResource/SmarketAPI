using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources;
using System;
using System.Transactions;

namespace Smarket.API.Service.Services
{
    public class ServiceBrand : ServiceBase<Brands>, IServiceBrand
    {

        private readonly IRepositoryBrand _repositoryBrand;

        public ServiceBrand(IRepositoryBrand repositoryBrand)
        {
            _repositoryBrand = repositoryBrand;
        }

        public BrandReturn GetBrandByDescription(string description)
        {
            var returnModel = new BrandReturn();

            returnModel = _repositoryBrand.GetBrandByDescription(description);

            return returnModel;
        }

        public BrandReturn GetBrandById(Guid id)
        {
            var returnModel = new BrandReturn();

            returnModel = _repositoryBrand.GetBrandById(id);

            return returnModel;
        }

        public BrandReturn GetBrands()
        {
            var returnModel = new BrandReturn();

            returnModel = _repositoryBrand.GetBrands();

            return returnModel;
        }

        public BaseReturn SaveBrand(Brands newBrand)
        {
            var returnModel = new BaseReturn();

            var brandExists = _repositoryBrand.Get(s => s.Description == newBrand.Description);

            if (brandExists == null)
            {
                using (var transaction = new TransactionScope())
                {

                    _repositoryBrand.AddBrand(newBrand);

                    _repositoryBrand.SaveChanges();

                    transaction.Complete();
                }
                returnModel.Message = GeneralMessagesEN.SaveBrandSuccess;

            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.SaveBrandAlreadyExists;
            }

            return returnModel;

        }

    }
}
