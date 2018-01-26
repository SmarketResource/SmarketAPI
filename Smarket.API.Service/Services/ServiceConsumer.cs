using System;
using System.Transactions;
using System.Linq;
using Smarket.API.Model.Commands;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using Smarket.API.Model.Context;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Domain.Interfaces.IRepositories;

namespace Smarket.API.Service.Services
{
    public class ServiceConsumer : ServiceBase<Consumers>, IServiceConsumer
    {

        private readonly IRepositoryConsumer _repositoryConsumer;
        private readonly IRepositoryUser _repositoryUser;
        private readonly IRepositoryPhone _repositoryPhone;

        public ServiceConsumer(IRepositoryConsumer repositoryConsumer,IRepositoryUser repositoryUser, IRepositoryPhone repositoryPhone)
        {
            _repositoryConsumer = repositoryConsumer;
            _repositoryUser = repositoryUser;
            _repositoryPhone = repositoryPhone;
        }   

        public ConsumerReturn GetConsumers()
        {
            var returnModel = new ConsumerReturn();

            returnModel = _repositoryConsumer.GetConsumers();

            return returnModel;
        }

        public BaseReturn SaveConsumer(Consumers consumer)
        {
            var returnModel = new BaseReturn();


            consumer.Users.TypeUserId   = 2;

            using(var transaction = new TransactionScope())
            {
                _repositoryConsumer.AddConsumer(consumer);
                _repositoryConsumer.SaveChanges();

                _repositoryUser.AddUser(consumer.Users);

                _repositoryPhone.AddPhone(consumer.Phones.FirstOrDefault());
                _repositoryConsumer.SaveChanges();

                transaction.Complete();
            }


            return returnModel;
        }

    }
}
