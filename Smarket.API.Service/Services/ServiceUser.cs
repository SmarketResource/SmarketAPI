using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
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

        public BaseReturn SaveUser(Users newUser)
        {
            var returnModel = new BaseReturn();

            var userExists = _repositoryUser.Get(u => u.UserLogin.ToUpper() == newUser.UserLogin.ToUpper());

            if (userExists == null)
            {
                using (var transaction = new TransactionScope())
                {

                    _repositoryUser.AddUser(newUser);

                    _repositoryUser.SaveChanges();

                    transaction.Complete();
                }

                returnModel.Message = GeneralMessages.SaveUserSuccess;
            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveUserAlreadyExists;
            }


            return returnModel;
        }

    }
}
