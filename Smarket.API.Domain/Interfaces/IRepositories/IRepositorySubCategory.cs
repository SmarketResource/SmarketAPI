using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositorySubCategory : IRepositoryBase<SubCategories>
    {

        SubCategoryReturn GetSubCategories();

        SubCategoryReturn GetSubCategoryById(Guid id);

        SubCategoryReturn GetSubCategoryByDescription(string description);

        SubCategoryReturn GetSubCategoryByCategory(Guid categoryId);

        SubCategories AddSubCategory(SubCategories subCategory);

    }
}
