using System.Transactions;
using System.Linq;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using Smarket.API.Model.Context;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Resources;

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

        public BaseReturn SaveConsumer(Consumers newConsumer)
        {
            var returnModel = new BaseReturn();

            newConsumer.Users.TypeUserId   = 2;

            var consumerExists = _repositoryUser.Get(s => s.UserLogin.ToUpper() == newConsumer.Users.UserLogin.ToUpper());

            if (consumerExists == null)
            {

                using (var transaction = new TransactionScope())
                {
                    _repositoryConsumer.AddConsumer(newConsumer);
                    _repositoryConsumer.SaveChanges();

                    _repositoryUser.AddUser(newConsumer.Users);

                    _repositoryPhone.AddPhone(newConsumer.Phones.FirstOrDefault());
                    _repositoryConsumer.SaveChanges();

                    transaction.Complete();
                }

                returnModel.Message = GeneralMessagesEN.SaveConsumerSuccess;

            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.SaveUserAlreadyExists;
            }

            return returnModel;

        }

        public BaseReturn UpdateConsumer(Consumers newConsumer)
        {
            var returnModel = new BaseReturn();

            var consumerExists = _repositoryUser.Get(s => s.UserLogin.ToUpper() == newConsumer.Users.UserLogin.ToUpper());

            if (consumerExists != null)
            {

                using (var transaction = new TransactionScope())
                {
                    _repositoryConsumer.ModifyConsumer(newConsumer);
                    _repositoryConsumer.SaveChanges();

                    transaction.Complete();
                }
                returnModel.Message = GeneralMessagesEN.UpdateConsumerSuccess;
            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.UpdateConsumerDoesNotExist;
            }

            return returnModel;
        }
    }
}
