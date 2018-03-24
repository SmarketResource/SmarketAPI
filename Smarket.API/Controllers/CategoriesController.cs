using AutoMapper;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Commands;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources.Utils;
using System;
using System.Web.Http;
using System.Web.Http.Description;
using Smarket.API.Resources;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;

namespace Smarket.API.Controllers
{
    /// <summary>
    /// CategoriesController Class
    /// </summary>
    public class CategoriesController : BaseController
    {
        private readonly IServiceCategory _serviceCategory;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// CategoriesController Constructor
        /// </summary>
        public CategoriesController(IServiceCategory serviceCategory, IServiceLog serviceLog)
        {
            _serviceCategory = serviceCategory;
            _serviceLog = serviceLog;
        }

        /// <summary>
        /// Save a Category
        /// </summary>
        /// <param name="command">Categories data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(BaseReturn))]
        public IHttpActionResult SaveCategory(SaveCategoryCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var category = Mapper.Map<SaveCategoryCommand, Categories>(command);

                returnModel = _serviceCategory.SaveCategory(category);

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
                returnModel.Message = GeneralMessagesEN.SaveCategoryError+ " : " + ex.Message;
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
        /// List all Categories in database
        /// </summary>
        /// <remarks>Return a list of categories</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(CategoryReturn))]
        public IHttpActionResult GetBrands()
        {
            var returnModel = new CategoryReturn();

            try
            {
                returnModel = _serviceCategory.GetCategories();
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

        /// <summary>
        /// Return a category by id
        /// </summary>
        /// <remarks>Return a category</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(CategoryReturn))]
        [Route("api/Categories/GetCategoryById/{id}")]
        public IHttpActionResult GetCagetoryById(Guid id)
        {
            var returnModel = new CategoryReturn();

            try
            {
                returnModel = _serviceCategory.GetCategoryById(id);
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

        /// <summary>
        /// Return a category by description
        /// </summary>
        /// <remarks>Return a category</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(CategoryReturn))]
        [Route("api/Categories/GetCategoryByDescription/{description}")]
        public IHttpActionResult GetCagetoryByDescription(string description)
        {
            var returnModel = new CategoryReturn();

            try
            {
                returnModel = _serviceCategory.GetCategoryByDescription(description);
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