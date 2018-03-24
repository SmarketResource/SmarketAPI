using AutoMapper;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace Smarket.API.Controllers
{

    /// <summary>
    /// BrandsController Class
    /// </summary>
    public class BrandsController : BaseController
    {

        private readonly IServiceBrand _serviceBrand;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// BrandsController Constructor
        /// </summary>
        public BrandsController(IServiceBrand serviceBrand, IServiceLog serviceLog)
        {
            _serviceBrand = serviceBrand;
            _serviceLog = serviceLog;
        }

        /// <summary>
        /// Save a Brand
        /// </summary>
        /// <param name="command">Brands data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [Authorize]
        public IHttpActionResult SaveBrand(SaveBrandCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var brand = Mapper.Map<SaveBrandCommand, Brands>(command);

                returnModel = _serviceBrand.SaveBrand(brand);

            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessages.SaveUserError + " : " + ex.Message;
                _serviceLog.SaveLog(returnModel.Message);
            }

            return Ok(returnModel);
        }

        /// <summary>
        /// List all Brands in database
        /// </summary>
        /// <remarks>Return a list of brands</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(BrandReturn))]
        public IHttpActionResult GetBrands()
        {
            var returnModel = new BrandReturn();

            try
            {
                returnModel = _serviceBrand.GetBrands();
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

        /// <summary>
        /// Return a brand by id
        /// </summary>
        /// <remarks>Return a brand</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(BrandReturn))]
        [Route("api/Brands/GetBrandById/{id}")]
        public IHttpActionResult GetBrandById(Guid id)
        {
            var returnModel = new BrandReturn();

            try
            {
                returnModel = _serviceBrand.GetBrandById(id);
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

        /// <summary>
        /// Return a brand by description
        /// </summary>
        /// <remarks>Return a brand</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(BrandReturn))]
        [Route("api/Brands/GetBrandByDescription/{description}")]
        public IHttpActionResult GetBrandByDescription(string description)
        {
            var returnModel = new BrandReturn();

            try
            {
                returnModel = _serviceBrand.GetBrandByDescription(description);
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