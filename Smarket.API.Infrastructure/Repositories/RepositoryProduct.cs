using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryProduct : RepositoryBase<Products>, IRepositoryProduct
    {

        private readonly SmarketContext _context;

        public RepositoryProduct(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public Products AddProduct(Products newProduct)
        {
            _context.Products.Add(newProduct);
            return newProduct;
        }

        public ProductReturn GetProductByDescription(string description)
        {
            var products = _context.Products.Where(p => p.Description == description).ToList();

            var returnModel = new ProductReturn { Products = Mapper.Map<List<Products>, List<ProductModel>>(products) };

            return returnModel;
        }

        public ProductReturn GetProductById(Guid id)
        {
            var products = _context.Products.Where(p => p.ProductId == id).ToList();

            var returnModel = new ProductReturn { Products = Mapper.Map<List<Products>, List<ProductModel>>(products) };

            return returnModel;
        }

        public ProductReturn GetProducts()
        {
            var products = _context.Products.ToList();

            var returnModel = new ProductReturn { Products = Mapper.Map<List<Products>, List<ProductModel>>(products) };

            return returnModel;
        }

        public ProductReturn GetProductsByMarket(Guid marketId)
        {
            var products = _context.Products.Where(p => p.MarketId == marketId).ToList();

            var returnModel = new ProductReturn { Products = Mapper.Map<List<Products>, List<ProductModel>>(products) };

            return returnModel;
        }

        public ProductReturn GetProductsBySubCategory(Guid subCategoryId)
        {
            var products = _context.Products.Where(p => p.SubCategoryId == subCategoryId).ToList();

            var returnModel = new ProductReturn { Products = Mapper.Map<List<Products>, List<ProductModel>>(products) };

            return returnModel;
        }
    }
}
