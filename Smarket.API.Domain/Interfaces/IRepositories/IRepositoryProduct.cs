using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryProduct : IRepositoryBase<Products>
    {

        ProductReturn GetProducts();

        ProductReturn GetProductById(Guid id);

        ProductReturn GetProductByDescription(string description);

        ProductReturn GetProductsByMarket(Guid marketId);

        ProductReturn GetProductsBySubCategory(Guid subCategoryId);

        Products AddProduct(Products newProduct);

    }
}
