using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System;
using System.Web.Http;

namespace Smarket.API.Controllers
{
    public class UsersController : BaseController
    {

        private readonly IServiceUser _serviceUser;
        private readonly IServiceLog _serviceLog;

        public UsersController(IServiceUser serviceUser, IServiceLog serviceLog)
        {
            _serviceUser = serviceUser;
            _serviceLog = serviceLog;
        }

        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var returnModel = new UserReturn();

            try
            {
                returnModel = _serviceUser.GetUsers();
                returnModel.Message = GeneralMessages.GetUsersSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.GetUsersError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);
            }
            
            return Ok(returnModel);
        }

    }
}