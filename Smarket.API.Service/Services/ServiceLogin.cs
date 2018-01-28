using AutoMapper;
using Newtonsoft.Json;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System;
using System.Linq;

namespace Smarket.API.Service.Services
{
    public class ServiceLogin : ServiceBase<Users>, IServiceLogin
    {
        private readonly IRepositoryUser _repositoryUser;

        public ServiceLogin(IRepositoryUser repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public bool CheckIfTokenIsValid(string token)
        {
            bool valid = false;
            if (!string.IsNullOrEmpty(token))
            {
                if (!token.StartsWith("Negotiate"))
                {
                    token = token.Replace("Basic ", string.Empty);
                    var tokenObj = JsonConvert.DeserializeObject<LoginReturnModel>(EncryptString.Decrypt(token));
                    if (tokenObj != null)
                    {
                        if (tokenObj.UserId != null && tokenObj.UserId != Guid.Empty)
                        {
                            if (tokenObj.Date.AddDays(1) > DateTime.Now)
                            {
                                valid = true;
                            }
                        }
                    }
                }
            }
            return valid;
        }

        public UserReturn Authenticate(string username, string password)
        {

            var user = _repositoryUser.Find(c => c.UserLogin == username && c.UserPass == password).FirstOrDefault();

            if (user == null)
            {
                return new UserReturn()
                {
                    Error = true,
                    Message = "Usuario e/ou Senha invalidos"

                };
            }

            user.UserLastAccess = DateTime.Now;

            _repositoryUser.SaveChanges();

            var returnModel = new UserReturn();
            returnModel.Users.Add(Mapper.Map<Users, UserModel>(user));
            returnModel.Message = "Usuario Autenticado com sucesso";
            returnModel.Error = false;

            return returnModel;
        }

    }
}
