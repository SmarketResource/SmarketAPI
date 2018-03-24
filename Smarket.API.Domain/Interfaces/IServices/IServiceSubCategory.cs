using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceSubCategory
    {

        SubCategoryReturn GetSubCategories();

        SubCategoryReturn GetSubCategoryById(Guid id);

        SubCategoryReturn GetSubCategoryByDescription(string description);

        SubCategoryReturn GetSubCategoryByCategory(Guid categoryId);

        BaseReturn SaveSubCategory(SubCategories newSubCategory);

    }
}
