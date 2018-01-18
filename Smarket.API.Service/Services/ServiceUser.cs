using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System;
using System.Linq;
using System.Transactions;

namespace Smarket.API.Service.Services
{
    public class ServiceUser : ServiceBase<Users>, IServiceUser
    {

        private readonly IRepositoryUser _repositoryUser;

        public ServiceUser(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public UserReturn GetUsers()
        {
            var returnModel = new UserReturn();

            returnModel = _repositoryUser.GetUsers();

            return returnModel;
        }

        public BaseReturn SaveUser(SaveUserCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                using(var transaction = new TransactionScope())
                {
                    _repositoryUser.AddUser(new Users
                    {
                        UserId      = Guid.NewGuid(),
                        TypeUserId  = command.TypeUserId,
                        UserLogin   = command.UserLogin,
                        UserPass    = command.UserPass
                    });

                    _repositoryUser.SaveChanges();

                    transaction.Complete();
                }

                returnModel.Message = GeneralMessages.SaveUserSuccess;
            }
            catch(TransactionAbortedException tex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveUserError + " : " + tex.Message;
                //ServiceLog.SaveLog(returnModel.Message);
            }
            catch(Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveUserError + " : " + ex.Message;
                //ServiceLog.SaveLog(returnModel.Message);
            }

            return returnModel;
        }

    }
}
