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
    public class RepositoryCategory : RepositoryBase<Categories>, IRepositoryCategory
    {

        private readonly SmarketContext _context;

        public RepositoryCategory(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }


        public Categories AddCategory(Categories category)
        {
            _context.Categories.Add(category);

            return category;        
        }

        public CategoryReturn GetCategories()
        {
            var categories = _context.Categories.ToList();

            var returnModel = new CategoryReturn { Categories = Mapper.Map<List<Categories>, List<CategoryModel>>(categories) };

            return returnModel;
        }

        public CategoryReturn GetCategoryByDescription(string description)
        {
            var categories = _context.Categories.Where(c => c.Description == description).ToList();

            var returnModel = new CategoryReturn { Categories = Mapper.Map<List<Categories>, List<CategoryModel>>(categories) };

            return returnModel;
        }

        public CategoryReturn GetCategoryById(Guid id)
        {
            var categories = _context.Categories.Where(c => c.CategoryId == id).ToList();

            var returnModel = new CategoryReturn { Categories = Mapper.Map<List<Categories>, List<CategoryModel>>(categories) };

            return returnModel;
        }
    }
}
