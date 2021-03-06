﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using AutoMapper;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// CommerceController Class
    /// </summary>
    public class CommerceController : BaseController
    {

        private readonly IServiceCommerce _serviceCommerce;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// CommerceController Constructor
        /// </summary>
        public CommerceController(IServiceCommerce serviceCommerce, IServiceLog serviceLog)
        {
            _serviceCommerce = serviceCommerce;
            _serviceLog = serviceLog;
        }

        /// <summary>
        /// List all Commerces in database
        /// </summary>
        /// <remarks>Return a list of commerce</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(CommerceReturn))]
        public IHttpActionResult GetCommerces()
        {
            var returnModel = new CommerceReturn();
            try
            {
                returnModel = _serviceCommerce.GetCommerces();
                returnModel.Message = GeneralMessages.GetCommercesSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.GetCommercesError + " : " + ex.Message;
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
        /// Save a commerce
        /// </summary>
        /// <param name="command">Commerce data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [ResponseType(typeof(BaseReturn))]
        public IHttpActionResult SaveCommerce(SaveCommerceCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var employee        = Mapper.Map<SaveCommerceCommand, CommerceEmployee>(command);
                employee.Users      = Mapper.Map<SaveCommerceCommand, Users>(command);
                employee.Users.TypeUserId = 3;
                employee.Phones     = new List<Phones> { Mapper.Map<SaveCommerceCommand, Phones>(command) };

                var commerce        = Mapper.Map<SaveCommerceCommand, Commerce>(command);
                commerce.CommerceEmployee   = new List<CommerceEmployee> { employee };

                returnModel = _serviceCommerce.SaveCommerce(commerce);

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
                returnModel.Message = GeneralMessages.SaveCommerceError + " : " + ex.Message;
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