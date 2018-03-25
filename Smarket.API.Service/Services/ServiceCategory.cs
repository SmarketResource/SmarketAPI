using System;
using System.Transactions;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources;

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

        public BaseReturn SaveCategory(Categories newCategory)
        {
            var returnModel = new BaseReturn();

            var subCategoryExists = _repositoryCategory.Get(s => s.Description.ToUpper() == newCategory.Description.ToUpper());

            if (subCategoryExists == null)
            {
                using (var transaction = new TransactionScope())
                {

                    _repositoryCategory.AddCategory(newCategory);

                    _repositoryCategory.SaveChanges();

                    transaction.Complete();
                }
                returnModel.Message = GeneralMessagesEN.SaveCategorySuccess;

            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.SaveCategoryAlreadyExists;
            }
            return returnModel;

        }
    }
}
