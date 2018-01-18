using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using Smarket.API.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Smarket.API.Controllers
{
    public class ConsumersController : BaseController
    {

        public readonly IServiceConsumer _serviceConsumer;
        public readonly IServiceLog _serviceLog;

        public ConsumersController(IServiceConsumer serviceConsumer, IServiceLog serviceLog)
        {
            _serviceConsumer = serviceConsumer;
            _serviceLog = serviceLog;
        }

        [HttpGet]
        public IHttpActionResult GetConsumers()
        {
            var returnModel = new ConsumerReturn();
            try
            {
                returnModel = _serviceConsumer.GetConsumers();
                returnModel.Message = GeneralMessages.GetConsumersSuccess;
            }
            catch(Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.GetConsumersError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);
            }

            return Ok(returnModel);
        }

        //[HttpPost]
        //public IHttpActionResult SaveConsumer()

    }
}