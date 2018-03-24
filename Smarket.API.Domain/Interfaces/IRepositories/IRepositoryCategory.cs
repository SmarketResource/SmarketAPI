using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryCategory : IRepositoryBase<Categories>
    {
        CategoryReturn GetCategories();

        CategoryReturn GetCategoryById(Guid id);

        CategoryReturn GetCategoryByDescription(string description);

        Categories AddCategory(Categories category);
    }
}
