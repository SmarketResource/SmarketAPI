using System;
using System.Web.Http;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using AutoMapper;
using Smarket.API.Model.Context;
using System.Collections.Generic;

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

                return Ok(returnModel);

            }

            return Ok(returnModel);
        }

        [HttpPost]
        public IHttpActionResult SaveConsumer(SaveConsumerCommand command)
        {
            var returnModel = new BaseReturn();
            try
            {
                var phone    = Mapper.Map<SaveConsumerCommand, Phones>(command);
                var user     = Mapper.Map<SaveConsumerCommand, Users>(command);
                var consumer = Mapper.Map<SaveConsumerCommand, Consumers>(command);

                var phones = new List<Phones>{ phone };

                consumer.Phones = phones;
                consumer.Users = user;

                returnModel = _serviceConsumer.SaveConsumer(consumer);

            }
            catch(Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveConsumerError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);
            }

            return Ok(returnModel);
        }

    }
}