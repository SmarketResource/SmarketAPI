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
    /// SubCategoriesController Class
    /// </summary>
    public class SubCategoriesController : BaseController
    {

        private readonly IServiceSubCategory _serviceSubCategory;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// SubCategoriesController Constructor
        /// </summary>
        public SubCategoriesController(IServiceSubCategory serviceSubCategory, IServiceLog serviceLog)
        {
            _serviceSubCategory = serviceSubCategory;
            _serviceLog = serviceLog;
        }

        /// <summary>
        /// Save a Subcategory
        /// </summary>
        /// <param name="command">Subcategories data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(BaseReturn))]
        public IHttpActionResult SaveSubCategory(SaveSubCategoryCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var subcategory = Mapper.Map<SaveSubCategoryCommand, SubCategories>(command);

                returnModel = _serviceSubCategory.SaveSubCategory(subcategory);

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
                returnModel.Message = GeneralMessagesEN.SaveCategoryError + " : " + ex.Message;
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
        /// List all subcategories in database
        /// </summary>
        /// <remarks>Return a list of subcategories</remarks>
        [HttpGet]
        [ResponseType(typeof(SubCategoryReturn))]
        public IHttpActionResult GetSubCategories()
        {
            var returnModel = new SubCategoryReturn();

            try
            {
                returnModel = _serviceSubCategory.GetSubCategories();
                returnModel.Message = GeneralMessagesEN.GetSubCategoriesSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetSubCategoriesError + " : " + ex.Message;
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
        /// Return a subcategory by id
        /// </summary>
        /// <remarks>Return a subcategory</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(SubCategoryReturn))]
        [Route("api/SubCategories/GetSubCategoryById/{id}")]
        public IHttpActionResult GetSubCagetoryById(Guid id)
        {
            var returnModel = new SubCategoryReturn();

            try
            {
                returnModel = _serviceSubCategory.GetSubCategoryById(id);
                returnModel.Message = GeneralMessagesEN.GetSubCategoryByIdSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetSubCategoryByIdError + " : " + ex.Message;
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
        /// Return a subcategory by description
        /// </summary>
        /// <remarks>Return a subcategory</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(SubCategoryReturn))]
        [Route("api/SubCategories/GetSubCategoryByDescription/{description}")]
        public IHttpActionResult GetCagetoryByDescription(string description)
        {
            var returnModel = new SubCategoryReturn();

            try
            {
                returnModel = _serviceSubCategory.GetSubCategoryByDescription(description);
                returnModel.Message = GeneralMessagesEN.GetSubCategoryByDescriptionSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetSubCategoryByDescriptionError + " : " + ex.Message;
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
        /// Return a subcategory by category
        /// </summary>
        /// <remarks>Return a subcategory</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(SubCategoryReturn))]
        [Route("api/SubCategories/GetSubCategoryByCategory/{categoryId}")]
        public IHttpActionResult GetCagetoryByCategory(Guid categoryId)
        {
            var returnModel = new SubCategoryReturn();

            try
            {
                returnModel = _serviceSubCategory.GetSubCategoryByCategory(categoryId);
                returnModel.Message = GeneralMessagesEN.GetSubCategoryByDescriptionSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetSubCategoryByCategoryError + " : " + ex.Message;
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