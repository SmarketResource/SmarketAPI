using System;
using System.Transactions;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;

namespace Smarket.API.Service.Services
{
    public class ServiceCategory : ServiceBase<Categories>, IServiceCategory
    {

        private readonly IRepositoryCategory _repositoryCategory;

        public ServiceCategory(IRepositoryCategory repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }

        public CategoryReturn GetCategories()
        {
            var returnModel = new CategoryReturn();

            returnModel = _repositoryCategory.GetCategories();

            return returnModel;
        }

        public CategoryReturn GetCategoryByDescription(string description)
        {
            var returnModel = new CategoryReturn();

            returnModel = _repositoryCategory.GetCategoryByDescription(description);

            return returnModel;
        }

        public CategoryReturn GetCategoryById(Guid id)
        {
            var returnModel = new CategoryReturn();

            returnModel = _repositoryCategory.GetCategoryById(id);

            return returnModel;
        }

        public BaseReturn SaveCategory(Categories category)
        {
            var returnModel = new BaseReturn();

            using (var transaction = new TransactionScope())
            {

                _repositoryCategory.AddCategory(category);

                _repositoryCategory.SaveChanges();

                transaction.Complete();
            }

            return returnModel;
        }
    }
}
