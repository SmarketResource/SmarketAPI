using AutoMapper;
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
using System.Web.Http.Description;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// CommerceController Class
    /// </summary>
    public class CommerceController : BaseController
    {

        public readonly IServiceCommerce _serviceCommerce;
        public readonly IServiceLog _serviceLog;

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

                return Ok(returnModel);

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