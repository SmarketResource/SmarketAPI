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
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;


namespace Smarket.API.Controllers
{
    /// <summary>
    /// MarketController Class
    /// </summary>
    public class MarketController : BaseController
    {
        private readonly IServiceMarket  _serviceMarket;
        private readonly IServiceLog     _serviceLog;

        /// <summary>
        /// MarketController Constructor
        /// </summary>
        public MarketController(IServiceMarket serviceMarket, IServiceLog serviceLog)
        {
            _serviceMarket  = serviceMarket;
            _serviceLog     = serviceLog;
        }

        /// <summary>
        /// List all Markets in database
        /// </summary>
        /// <remarks>Return a list of markets</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(MarketReturn))]
        public IHttpActionResult GetMarkets()
        {
            var returnModel = new MarketReturn();
            try
            {
                returnModel         = _serviceMarket.GetMarkets();
                returnModel.Message = GeneralMessages.GetMarketsSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.GetMarketsError + " : " + ex.Message;
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
        /// Save a Market
        /// </summary>
        /// <param name="command">Market data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [ResponseType(typeof(BaseReturn))]
        public IHttpActionResult SaveMarket(SaveMarketCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var employee    = Mapper.Map<SaveMarketCommand, MarketEmployee>(command);
                employee.Users  = Mapper.Map<SaveMarketCommand, Users>(command);
                employee.Users.TypeUserId = 4;
                employee.Phones = new List<Phones> { Mapper.Map<SaveMarketCommand, Phones>(command) };

                var market      = Mapper.Map<SaveMarketCommand, Market>(command);
                market.MarketEmployee = new List<MarketEmployee> { employee };
                market.Address  = Mapper.Map<SaveMarketCommand, Address>(command);

                returnModel = _serviceMarket.SaveMarket(market);
                returnModel.Message = GeneralMessages.SaveMarketSuccess;

            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveMarketError + " : " + ex.Message;
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