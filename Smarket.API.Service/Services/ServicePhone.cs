using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smarket.API.Model.Returns;
using Smarket.API.Domain.Interfaces.IRepositories;
using System.Transactions;

namespace Smarket.API.Service.Services
{
    public class ServicePhone : ServiceBase<Phones>, IServicePhone
    {
        private readonly IRepositoryPhone _repositoryPhone;

        public ServicePhone(IRepositoryPhone repositoryPhone)
        {
            _repositoryPhone = repositoryPhone;
        }

        public BaseReturn SavePhone(Phones phone)
        {
            var returnModel = new BaseReturn();

            using(var transaction = new TransactionScope())
            {
                phone.PhoneId = Guid.NewGuid();

                _repositoryPhone.AddPhone(phone);

                _repositoryPhone.SaveChanges();

                transaction.Complete();
            }

            return returnModel;
        }
    }
}
