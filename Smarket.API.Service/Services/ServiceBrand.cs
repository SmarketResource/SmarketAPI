using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public BaseReturn SaveBrand(Brands brand)
        {
            var returnModel = new BaseReturn();

            using (var transaction = new TransactionScope())
            {

                _repositoryBrand.AddBrand(brand);

                _repositoryBrand.SaveChanges();

                transaction.Complete();
            }

            return returnModel;
        }

    }
}
