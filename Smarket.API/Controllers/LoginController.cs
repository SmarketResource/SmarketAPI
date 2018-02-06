using System;
using Newtonsoft.Json;
using Smarket.API.Model.Commands;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System.Web.Http;
using Smarket.API.Domain.Interfaces.IServices;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// LoginController Class
    /// </summary>
    public class LoginController : ApiController
    {
        private readonly IServiceLogin _serviceLogin;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// LoginController Constructor
        /// </summary>
        public LoginController(IServiceLogin serviceLogin, IServiceLog serviceLog)
        {
            if (serviceLog == null) throw new ArgumentNullException("serviceLog");

            _serviceLogin = serviceLogin;
            _serviceLog = serviceLog;
        }

        /// <summary>
        /// Method generate Basic Token to allow some API's
        /// </summary>
        /// <remarks>Return a object with basic token</remarks>
        [HttpGet]
        [ResponseType(typeof(LoginReturn))]
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
    }
}