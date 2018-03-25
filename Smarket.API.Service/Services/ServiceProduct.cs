using System;
using System.Transactions;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources;

namespace Smarket.API.Service.Services
{
    public class ServiceProduct : ServiceBase<Products>, IServiceProduct
    {

        private readonly IRepositoryProduct _repositoryProduct;

        public ServiceProduct(IRepositoryProduct repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public BaseReturn SaveProduct(Products newProduct)
        {
            var returnModel = new BaseReturn();

            var productExists = _repositoryProduct.Get(s => s.Description.ToUpper() == newProduct.Description.ToUpper() && s.MarketId == newProduct.MarketId);

            if (productExists == null)
            {
                using (var transaction = new TransactionScope())
                {

                    _repositoryProduct.AddProduct(newProduct);

                    _repositoryProduct.SaveChanges();

                    transaction.Complete();
                }

                returnModel.Message = GeneralMessagesEN.SaveProductSuccess;
            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.SaveBrandAlreadyExists;
            }
            return returnModel;
        }

        public ProductReturn GetProductByDescription(string description)
        {
            var returnModel = new ProductReturn();

            returnModel = _repositoryProduct.GetProductByDescription(description);

            return returnModel;
        }

        public ProductReturn GetProductById(Guid id)
        {
            var returnModel = new ProductReturn();

            returnModel = _repositoryProduct.GetProductById(id);

            return returnModel;
        }

        public ProductReturn GetProducts()
        {
            var returnModel = new ProductReturn();

            returnModel = _repositoryProduct.GetProducts();

            return returnModel;
        }

        public ProductReturn GetProductsByMarket(Guid marketId)
        {
            var returnModel = new ProductReturn();

            returnModel = _repositoryProduct.GetProductsByMarket(marketId);

            return returnModel;
        }

        public ProductReturn GetProductsBySubCategory(Guid subCategoryId)
        {
            var returnModel = new ProductReturn();

            returnModel = _repositoryProduct.GetProductsBySubCategory(subCategoryId);

            return returnModel;
        }

        public ProductReturn GetProductsByBrand(Guid brandId)
        {
            var returnModel = new ProductReturn();

            returnModel = _repositoryProduct.GetProductsByBrand(brandId);

            return returnModel;
        }
    }
}
