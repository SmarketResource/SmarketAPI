using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using AutoMapper;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources;
using Smarket.API.Resources.Utils;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// CityController Class
    /// </summary>
    public class CityController : BaseController
    {

        private readonly IServiceCity _serviceCity;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// CityController Constructor
        /// </summary>
        public CityController(IServiceCity serviceCity, IServiceLog serviceLog)
        {
            _serviceCity = serviceCity;
            _serviceLog = serviceLog;
        }

        /// <summary>
        /// Save a city
        /// </summary>
        /// <param name="command">City data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [ResponseType(typeof(BaseReturn))]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IHttpActionResult SaveListCity(List<SaveCityCommand> command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var cities = Mapper.Map<List<SaveCityCommand>, List<Cities>>(command);

                returnModel = _serviceCity.SaveListCity(cities);
                returnModel.Message = GeneralMessagesPT.SaveCommerceSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesPT.SaveCommerceError + " : " + ex.Message;
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
        /// List all Cities by stateId in database
        /// </summary>
        /// <remarks>Return a list of cities</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(CityReturn))]
        [Route("api/City/GetCitiesByStateId/{stateId}")]
        public IHttpActionResult GetCitiesByStateId(int stateId)
        {
            var returnModel = new CityReturn();

            try
            {
                returnModel = _serviceCity.GetCitiesByStateId(stateId);
                returnModel.Message = GeneralMessages.GetCitiesSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.GetCitiesError + " : " + ex.Message;
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