using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using Smarket.API.Resources;
using System;
using System.Linq;
using System.Transactions;

namespace Smarket.API.Service.Services
{
    public class ServiceCommerce : ServiceBase<Commerce>, IServiceCommerce
    {
        private readonly IRepositoryCommerce _repositoryCommerce;
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryPhone _repositoryPhone;


        public ServiceCommerce(IRepositoryCommerce repositoryCommerce, IRepositoryUser repositoryUser, IRepositoryPhone repositoryPhone)
        {
            _repositoryCommerce = repositoryCommerce;
            _repositoryUser = repositoryUser;
            _repositoryPhone = repositoryPhone;
        }

        public CommerceReturn GetCommerces()
        {
            var returnModel = new CommerceReturn();

            returnModel = _repositoryCommerce.GetCommerces();

            return returnModel;
        }

        public BaseReturn SaveCommerce(Commerce newCommerce)
        {
            var returnModel = new BaseReturn();

            var commerceExists = _repositoryCommerce.Get(m => m.FantasyName == newCommerce.FantasyName);

            if (commerceExists == null)
            {


                using (var transaction = new TransactionScope())
                {

                    _repositoryCommerce.AddCommerce(newCommerce);

                    _repositoryCommerce.SaveChanges();

                    var Employee = newCommerce.CommerceEmployee.FirstOrDefault();

                    var EmployeeUser = Employee.Users;

                    _repositoryUser.AddUser(EmployeeUser);

                    _repositoryPhone.AddPhone(Employee.Phones.FirstOrDefault());

                    _repositoryCommerce.SaveChanges();

                    transaction.Complete();
                }

                returnModel.Message = GeneralMessagesEN.SaveCommerceSuccess;
            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.SaveCommerceAlreadyExists;
            }

            return returnModel;

        }
    }
}
