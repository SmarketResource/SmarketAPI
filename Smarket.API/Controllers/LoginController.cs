using System;
using Newtonsoft.Json;
using Smarket.API.Model.Commands;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System.Web.Http;
using Smarket.API.Domain.Interfaces.IServices;
using System.Web.Http.Cors;

namespace Smarket.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET,POST")]
    public class LoginController : ApiController
    {
        private  IServiceLogin _serviceLogin;
        private  IServiceLog _serviceLog;

        public LoginController(IServiceLogin serviceLogin, IServiceLog serviceLog)
        {
            if (serviceLog == null) throw new ArgumentNullException("serviceLog");

            _serviceLogin = serviceLogin;
            _serviceLog = serviceLog;
        }
        
        [HttpGet]
        public IHttpActionResult GetGeneratedToken()
        {
            var returnModel = new LoginReturn();

            try
            {
                returnModel.Token = EncryptString.Encrypt(JsonConvert.SerializeObject(new LoginReturnModel() { Date = DateTime.Now, UserId = Guid.NewGuid() }, Formatting.None));
            }
            catch(Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.GetGeneratedTokenError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);
            }
            return Ok(returnModel);
        }

        [HttpPost]
        public IHttpActionResult AuthUser(AuthUserCommand command)
        {
            string token = this.ActionContext.Request.Headers.Authorization.ToString();

            if (_serviceLogin.CheckIfTokenIsValid(token))
            {
                return Ok(_serviceLogin.Authenticate(command.UserLogin, command.UserPass));
            }
            return Ok("Token invalido");
        }

    }
}