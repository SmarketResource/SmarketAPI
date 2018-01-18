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

        public ServiceConsumer(IRepositoryConsumer repositoryConsumer,IRepositoryUser repositoryUser)
        {
            _repositoryConsumer = repositoryConsumer;
            _repositoryUser = repositoryUser;
        }   

        public ConsumerReturn GetConsumers()
        {
            var returnModel = new ConsumerReturn();

            returnModel = _repositoryConsumer.GetConsumers();

            return returnModel;
        }

        public BaseReturn SaveConsumer(SaveConsumerCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                using(var transaction = new TransactionScope())
                {

                    _repositoryUser.AddUser(new Users
                    {
                        UserId      = Guid.NewGuid(),
                        TypeUserId  = 2,
                        UserLogin   = command.UserLogin,
                        UserPass    = command.UserPass
                    });


                }
            }
            catch(TransactionAbortedException tex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveConsumerError + " : " + tex.Message;
                //ServiceLog.SaveLog(returnModel.Message);
            }
            catch(Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveConsumerError + " : " + ex.Message;
                //ServiceLog.SaveLog(returnModel.Message);
            }

            return returnModel;
        }

    }
}
