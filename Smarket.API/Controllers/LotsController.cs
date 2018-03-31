using AutoMapper;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// LotsController Class
    /// </summary>
    public class LotsController : BaseController
    {
        private readonly IServiceLot _serviceLot;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// LotsController Constructor
        /// </summary>
        public LotsController(IServiceLot serviceLot, IServiceLog serviceLog)
        {
            _serviceLot = serviceLot;
            _serviceLog = serviceLog;
        }


        /// <summary>
        /// Save a Lot
        /// </summary>
        /// <param name="command">Lots data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(BaseReturn))]
        public IHttpActionResult SaveLot(SaveLotCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var lot = Mapper.Map<SaveLotCommand, Lots>(command);

                returnModel = _serviceLot.SaveLot(lot);

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
                returnModel.Message = GeneralMessagesEN.SaveLotError + " : " + ex.Message;
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
        /// List all lots in database
        /// </summary>
        /// <remarks>Return a list of lots</remarks>
        [HttpGet]
        [ResponseType(typeof(LotReturn))]
        public IHttpActionResult GetLots()
        {
            var returnModel = new LotReturn();

            try
            {
                returnModel = _serviceLot.GetLots();
                returnModel.Message = GeneralMessagesEN.GetLotsSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetLotsError + " : " + ex.Message;
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
        /// Return a lot by id
        /// </summary>
        /// <remarks>Return a lot</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(LotReturn))]
        [Route("api/Lots/GetLotById/{id}")]
        public IHttpActionResult GetLotById(Guid id)
        {
            var returnModel = new LotReturn();

            try
            {
                returnModel = _serviceLot.GetLotById(id);
                returnModel.Message = GeneralMessagesEN.GetLotByIdSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetLotByIdError + " : " + ex.Message;
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
        /// Return a lot by description
        /// </summary>
        /// <remarks>Return a lot</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(LotReturn))]
        [Route("api/Lots/GetLotByDescription/{description}")]
        public IHttpActionResult GetLotByDescription(string description)
        {
            var returnModel = new LotReturn();

            try
            {
                returnModel = _serviceLot.GetLotByDescription(description);
                returnModel.Message = GeneralMessagesEN.GetLotByDescriptionSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetLotByDescriptionError + " : " + ex.Message;
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
        /// Return a list of lots by product
        /// </summary>
        /// <remarks>Return a lot</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(LotReturn))]
        [Route("api/Lots/GetLotsByProduct/{productId}")]
        public IHttpActionResult GetLotsByProduct(Guid productId)
        {
            var returnModel = new LotReturn();

            try
            {
                returnModel = _serviceLot.GetLotsByProduct(productId);
                returnModel.Message = GeneralMessagesEN.GetLotsByProductSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetLotsByProductError + " : " + ex.Message;
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
        /// Return a list of lots by market
        /// </summary>
        /// <remarks>Return a lot</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(LotReturn))]
        [Route("api/Lots/GetLotsByMarket/{marketId}")]
        public IHttpActionResult GetLotsByMarket(Guid marketId)
        {
            var returnModel = new LotReturn();

            try
            {
                returnModel = _serviceLot.GetLotsByMarket(marketId);
                returnModel.Message = GeneralMessagesEN.GetLotsByMarketSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetLotsByMarketError + " : " + ex.Message;
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