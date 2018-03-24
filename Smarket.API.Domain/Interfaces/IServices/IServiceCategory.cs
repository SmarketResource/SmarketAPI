using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceCategory
    {
        CategoryReturn GetCategories();

        CategoryReturn GetCategoryById(Guid id);

        CategoryReturn GetCategoryByDescription(string description);

        BaseReturn SaveCategory(Categories newCategory);

    }
}
