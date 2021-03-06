﻿using System;
using System.Web.Http;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using AutoMapper;
using Smarket.API.Model.Context;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Net.Http;
using System.Net;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// ConsumersController Class
    /// </summary>
    public class ConsumersController : BaseController
    {
        #region Services
        private readonly IServiceConsumer _serviceConsumer;
        private readonly IServiceLog _serviceLog;
        #endregion  

        /// <summary>
        /// ConsumersController Constructor
        /// </summary>
        public ConsumersController(IServiceConsumer serviceConsumer, IServiceLog serviceLog)
        {
            _serviceConsumer = serviceConsumer;
            _serviceLog = serviceLog;
        }

        /// <summary>
        /// List all consumers in database
        /// </summary>
        /// <remarks>Return a list of consumers</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(ConsumerReturn))]
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

                return new ResponseMessageResult(
                    Request.CreateErrorResponse(
                        (HttpStatusCode.BadRequest),
                        new HttpError(returnModel.Message)
                    )
                );
            }
            return Ok(returnModel);
        }

        /// <summary>
        /// Save a consumer
        /// </summary>
        /// <param name="command">Consumer data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [ResponseType(typeof(BaseReturn))]
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

                if (returnModel.Error)
                {
                    return new ResponseMessageResult(
                        Request.CreateErrorResponse(
                            (HttpStatusCode.BadRequest),
                            new HttpError(returnModel.Message)
                        )
                    );
                }
            }
            catch(Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveConsumerError + " : " + ex.Message;
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

        /// <summary>
        /// Update a consumer
        /// </summary>
        /// <param name="command">Consumer data</param>
        /// <remarks>Return a message if success or failed</remarks>
        /// 
        [HttpPut]
        [ResponseType(typeof(BaseReturn))]
        public IHttpActionResult UpdateConsumer(SaveConsumerCommand command)
        {
            var returnModel = new BaseReturn();
            try
            {
                var phone = Mapper.Map<SaveConsumerCommand, Phones>(command);
                var user = Mapper.Map<SaveConsumerCommand, Users>(command);
                var consumer = Mapper.Map<SaveConsumerCommand, Consumers>(command);

                var phones = new List<Phones> { phone };

                consumer.Phones = phones;
                consumer.Users = user;

                returnModel = _serviceConsumer.SaveConsumer(consumer);

                if (returnModel.Error)
                {
                    return new ResponseMessageResult(
                        Request.CreateErrorResponse(
                            (HttpStatusCode.BadRequest),
                            new HttpError(returnModel.Message)
                        )
                    );
                }
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveConsumerError + " : " + ex.Message;
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