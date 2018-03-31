using System;
using Newtonsoft.Json;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System.Web.Http;
using Smarket.API.Domain.Interfaces.IServices;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Net.Http;
using System.Net;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// LoginController Class
    /// </summary>
    public class BasicTokenController : ApiController
    {
        private readonly IServiceLogin _serviceLogin;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// LoginController Constructor
        /// </summary>
        public BasicTokenController(IServiceLogin serviceLogin, IServiceLog serviceLog)
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

                return new ResponseMessageResult(
                    Request.CreateErrorResponse(
                        (HttpStatusCode.BadRequest),
                        new HttpError(returnModel.Message)
                    )
                );
            }
            return Ok(returnModel);
        }
    }
}