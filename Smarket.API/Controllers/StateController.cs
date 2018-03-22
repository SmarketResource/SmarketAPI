using System;
using System.Web.Http;
using System.Web.Http.Description;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// StateController Class
    /// </summary>
    public class StateController : BaseController
    {

        private readonly IServiceState _serviceState;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// StateController Constructor
        /// </summary>
        public StateController(IServiceState serviceState, IServiceLog serviceLog)
        {
            _serviceState = serviceState;
            _serviceLog = serviceLog;
        }

        /// <summary>
        /// List all States in database
        /// </summary>
        /// <remarks>Return a list of states</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(StateReturn))]
        public IHttpActionResult GetStates()
        {
            var returnModel = new StateReturn();

            try
            {
                returnModel = _serviceState.GetStates();
                returnModel.Message = GeneralMessages.GetStatesSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.GetStatesError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);
            }

            return Ok(returnModel);
        }

    }
}