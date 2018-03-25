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
    /// ProductsController Class
    /// </summary>
    public class ProductsController : BaseController
    {

        private readonly IServiceProduct _serviceProduct;
        private readonly IServiceLog _serviceLog;

        /// <summary>
        /// ProductsController Constructor
        /// </summary>
        public ProductsController(IServiceProduct serviceProduct, IServiceLog serviceLog)
        {
            _serviceProduct = serviceProduct;
            _serviceLog = serviceLog;
        }


        /// <summary>
        /// Save a Product
        /// </summary>
        /// <param name="command">Products data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [HttpPost]
        [Authorize]
        [ResponseType(typeof(BaseReturn))]
        public IHttpActionResult SaveProduct(SaveProductCommand command)
        {
            var returnModel = new BaseReturn();

            try
            {
                var product = Mapper.Map<SaveProductCommand, Products>(command);

                returnModel = _serviceProduct.SaveProduct(product);

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
                returnModel.Message = GeneralMessagesEN.SaveProductError + " : " + ex.Message;
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
        /// List all products in database
        /// </summary>
        /// <remarks>Return a list of products</remarks>
        [HttpGet]
        [ResponseType(typeof(ProductReturn))]
        public IHttpActionResult GetProducts()
        {
            var returnModel = new ProductReturn();

            try
            {
                returnModel = _serviceProduct.GetProducts();
                returnModel.Message = GeneralMessagesEN.GetProductsSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetProductsError + " : " + ex.Message;
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
        /// Return a product by id
        /// </summary>
        /// <remarks>Return a product</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(ProductReturn))]
        [Route("api/Products/GetProductById/{id}")]
        public IHttpActionResult GetProductById(Guid id)
        {
            var returnModel = new ProductReturn();

            try
            {
                returnModel = _serviceProduct.GetProductById(id);
                returnModel.Message = GeneralMessagesEN.GetProductByIdSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetProductByIdError + " : " + ex.Message;
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
        /// Return a product by description
        /// </summary>
        /// <remarks>Return a product</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(ProductReturn))]
        [Route("api/Products/GetProductByDescription/{description}")]
        public IHttpActionResult GetProductByDescription(string description)
        {
            var returnModel = new ProductReturn();

            try
            {
                returnModel = _serviceProduct.GetProductByDescription(description);
                returnModel.Message = GeneralMessagesEN.GetProductByDescriptionSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetProductByDescriptionError + " : " + ex.Message;
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
        /// Return a list of products by subcategory
        /// </summary>
        /// <remarks>Return a product</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(ProductReturn))]
        [Route("api/Products/GetProductsBySubCategory/{subCategoryId}")]
        public IHttpActionResult GetProductsBySubCategory(Guid subCategoryId)
        {
            var returnModel = new ProductReturn();

            try
            {
                returnModel = _serviceProduct.GetProductsBySubCategory(subCategoryId);
                returnModel.Message = GeneralMessagesEN.GetProductsBySubCategorySuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetProductsBySubCategoryError + " : " + ex.Message;
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
        /// Return a list of products by market
        /// </summary>
        /// <remarks>Return a product</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(ProductReturn))]
        [Route("api/Products/GetProductsByMarket/{marketId}")]
        public IHttpActionResult GetProductsByMarket(Guid marketId)
        {
            var returnModel = new ProductReturn();

            try
            {
                returnModel = _serviceProduct.GetProductsByMarket(marketId);
                returnModel.Message = GeneralMessagesEN.GetProductsByMarketSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetProductsByMarketError + " : " + ex.Message;
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
        /// Return a list of products by brand
        /// </summary>
        /// <remarks>Return a product</remarks>
        [HttpGet]
        [Authorize]
        [ResponseType(typeof(ProductReturn))]
        [Route("api/Products/GetProductsByBrand/{brandId}")]
        public IHttpActionResult GetProductsByBrand(Guid brandId)
        {
            var returnModel = new ProductReturn();

            try
            {
                returnModel = _serviceProduct.GetProductsByBrand(brandId);
                returnModel.Message = GeneralMessagesEN.GetProductByBrandSuccess;
            }
            catch (Exception ex)
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.GetProductByBrandError + " : " + ex.Message;
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