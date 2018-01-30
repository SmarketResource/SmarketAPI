﻿using AutoMapper;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Smarket.API.Controllers
{
    public class CommerceController : BaseController
    {

        public readonly IServiceCommerce _serviceCommerce;
        public readonly IServiceLog _serviceLog;

        public CommerceController(IServiceCommerce serviceCommerce, IServiceLog serviceLog)
        {
            _serviceCommerce = serviceCommerce;
            _serviceLog = serviceLog;
        }

        /// <summary>
        /// List all Commerces in database
        /// </summary>
        /// <returns>Return a list of commerce</returns>
        [Authorize]
        [HttpGet]
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

                return Ok(returnModel);

            }

            return Ok(returnModel);
        }

        /// <summary>
        /// Save a commerce
        /// </summary>
        /// <param name="command">Commerce data</param>
        /// <returns>Return a message if success or failed</returns>
        [Authorize]
        [HttpPost]
        public IHttpActionResult SaveCommerce(SaveCommerceCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var employee        = Mapper.Map<SaveCommerceCommand, Employee>(command);
                employee.Users      = Mapper.Map<SaveCommerceCommand, Users>(command);
                employee.Users.TypeUserId = 3;
                employee.Phones     = new List<Phones> { Mapper.Map<SaveCommerceCommand, Phones>(command) };

                var commerce        = Mapper.Map<SaveCommerceCommand, Commerce>(command);
                commerce.Employee   = new List<Employee> { employee };

                returnModel = _serviceCommerce.SaveCommerce(commerce);
                returnModel.Message = GeneralMessages.SaveCommerceSuccess;

            }
            catch(Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveCommerceError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);
            }

            return Ok(returnModel);
        }



    }
}