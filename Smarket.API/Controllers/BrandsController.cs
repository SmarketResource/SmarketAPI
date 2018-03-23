using Smarket.API.Domain.Interfaces.IServices;
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
        [Route("Brands/GetBrandById/{id}")]
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
        [Route("Brands/GetBrandByDescription/{description}")]
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