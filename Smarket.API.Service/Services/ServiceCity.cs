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
    public class ServiceCity : ServiceBase<Cities>, IServiceCity
    {

        private readonly IRepositoryCity _repositoryCity;

        public ServiceCity(IRepositoryCity repositoryCity)
        {
            _repositoryCity = repositoryCity;
        }

        public CityReturn GetCitiesByStateId(int stateId)
        {
            var returnModel = new CityReturn();

            returnModel = _repositoryCity.GetCitiesByStateId(stateId);

            return returnModel;
        }

        public CityReturn GetCities()
        {
            var returnModel = new CityReturn();

            returnModel = _repositoryCity.GetCities();

            return returnModel;
        }

        public BaseReturn SaveCity(Cities city)
        {
            var returnModel = new BaseReturn();

            using (var transaction = new TransactionScope())
            {

                _repositoryCity.AddCity(city);

                _repositoryCity.SaveChanges();

                transaction.Complete();
            }

            return returnModel;
        }

        public BaseReturn SaveListCity(List<Cities> list)
        {
            var returnModel = new BaseReturn();

            foreach (var city in list)
            {
                _repositoryCity.AddCity(city);
            }

            _repositoryCity.SaveChanges();

            return returnModel;

        }
    }
}
