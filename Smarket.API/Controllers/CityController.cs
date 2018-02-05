using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;

namespace Smarket.API.Controllers
{
    public class CityController : BaseController
    {

        public readonly IServiceCity _serviceCity;
        public readonly IServiceLog _serviceLog;

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
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveCommerceError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);
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
            }

            return Ok(returnModel);
        }
    }
}