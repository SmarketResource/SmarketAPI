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
    public class RepositorySubCategory : RepositoryBase<SubCategories>, IRepositorySubCategory
    {

        private readonly SmarketContext _context;

        public RepositorySubCategory(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public SubCategories AddSubCategory(SubCategories newSubCategory)
        {
            _context.SubCategories.Add(newSubCategory);
            return newSubCategory;
        }

        public SubCategoryReturn GetSubCategories()
        {
            var subCategories = _context.SubCategories.Select(s => s).ToList();

            var returnModel = new SubCategoryReturn { SubCategories = Mapper.Map<List<SubCategories>, List<SubCategoryModel>>(subCategories) };

            return returnModel;
        }

        public SubCategoryReturn GetSubCategoryByCategory(Guid categoryId)
        {
            var subCategories = _context.SubCategories.Where(s => s.CategoryId == categoryId).ToList();

            var returnModel = new SubCategoryReturn { SubCategories = Mapper.Map<List<SubCategories>, List<SubCategoryModel>>(subCategories) };

            return returnModel;
        }

        public SubCategoryReturn GetSubCategoryByDescription(string description)
        {
            var subCategories = _context.SubCategories.Where(s => s.Description == description).ToList();

            var returnModel = new SubCategoryReturn { SubCategories = Mapper.Map<List<SubCategories>, List<SubCategoryModel>>(subCategories) };

            return returnModel;
        }

        public SubCategoryReturn GetSubCategoryById(Guid id)
        {
            var subCategories = _context.SubCategories.Where(s => s.SubCategoryId == id).ToList();

            var returnModel = new SubCategoryReturn { SubCategories = Mapper.Map<List<SubCategories>, List<SubCategoryModel>>(subCategories) };

            return returnModel;
        }
    }
}
