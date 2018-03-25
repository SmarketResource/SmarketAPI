using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources;
using System.Linq;
using System.Transactions;

namespace Smarket.API.Service.Services
{
    public class ServiceMarket : ServiceBase<Market>, IServiceMarket
    {

        private readonly IRepositoryMarket  _repositoryMarket;
        private readonly IRepositoryUser    _repositoryUser;
        private readonly IRepositoryPhone   _repositoryPhone;
        private readonly IRepositoryAddress _repositoryAddress;

        public ServiceMarket(IRepositoryMarket repositoryMarket, IRepositoryUser repositoryUser, IRepositoryPhone repositoryPhone, IRepositoryAddress repositoryAddress)
        {
            _repositoryMarket   = repositoryMarket;
            _repositoryUser     = repositoryUser;
            _repositoryPhone    = repositoryPhone;
            _repositoryAddress = repositoryAddress;
        }

        public MarketReturn GetMarkets()
        {
            var returnModel = new MarketReturn();

            returnModel = _repositoryMarket.GetMarkets();

            return returnModel;
        }

        public BaseReturn SaveMarket(Market newMarket)
        {
            var returnModel = new BaseReturn();

            var marketExists = _repositoryMarket.Get(m => m.FantasyName.ToUpper()   == newMarket.FantasyName.ToUpper() 
                                                       || m.SocialName.ToUpper()    == newMarket.SocialName.ToUpper() 
                                                       || m.CNPJ                    == newMarket.CNPJ);

            if (marketExists == null)
            {

                using (var transaction = new TransactionScope())
                {

                    _repositoryMarket.AddMarket(newMarket);

                    _repositoryMarket.SaveChanges();

                    var Employee = newMarket.MarketEmployee.FirstOrDefault();

                    var EmployeeUser = Employee.Users;

                    var MarketAddress = newMarket.Address;

                    _repositoryAddress.AddAddress(MarketAddress);

                    _repositoryUser.AddUser(EmployeeUser);

                    _repositoryPhone.AddPhone(Employee.Phones.FirstOrDefault());

                    _repositoryMarket.SaveChanges();

                    transaction.Complete();
                }

                returnModel.Message = GeneralMessagesEN.SaveMarketSuccess;

            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.SaveMarketAlreadyExists;
            }

            return returnModel;
        }
    }
}
