using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceProduct
    {

        ProductReturn GetProducts();

        ProductReturn GetProductById(Guid id);

        ProductReturn GetProductByDescription(string description);

        ProductReturn GetProductsByMarket(Guid marketId);

        ProductReturn GetProductsBySubCategory(Guid subCategoryId);

        BaseReturn SaveProduct(Products newProduct);

    }
}
