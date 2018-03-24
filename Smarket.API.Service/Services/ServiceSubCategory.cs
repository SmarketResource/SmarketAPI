using System;
using System.Transactions;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using Smarket.API.Resources;
using Smarket.API.Resources.Utils;

namespace Smarket.API.Service.Services
{
    public class ServiceSubCategory : ServiceBase<SubCategories>, IServiceSubCategory
    {

        private readonly IRepositorySubCategory _repositorySubCategory;

        public ServiceSubCategory(IRepositorySubCategory repositorySubCategory)
        {
            _repositorySubCategory = repositorySubCategory;
        }

        public SubCategoryReturn GetSubCategories()
        {
            var returnModel = new SubCategoryReturn();

            returnModel = _repositorySubCategory.GetSubCategories();

            return returnModel;
        }

        public SubCategoryReturn GetSubCategoryByCategory(Guid categoryId)
        {
            var returnModel = new SubCategoryReturn();

            returnModel = _repositorySubCategory.GetSubCategoryByCategory(categoryId);

            return returnModel;
        }

        public SubCategoryReturn GetSubCategoryByDescription(string description)
        {
            var returnModel = new SubCategoryReturn();

            returnModel = _repositorySubCategory.GetSubCategoryByDescription(description);

            return returnModel;
        }

        public SubCategoryReturn GetSubCategoryById(Guid id)
        {
            var returnModel = new SubCategoryReturn();

            returnModel = _repositorySubCategory.GetSubCategoryById(id);

            return returnModel;
        }

        public BaseReturn SaveSubCategory(SubCategories newSubCategory)
        {
            var returnModel = new BaseReturn();

            var subCategoryExists = _repositorySubCategory.Get(s => s.Description == newSubCategory.Description);

            if (subCategoryExists == null)
            {
                using (var transaction = new TransactionScope())
                {

                    _repositorySubCategory.AddSubCategory(newSubCategory);

                    _repositorySubCategory.SaveChanges();

                    transaction.Complete();
                }

                returnModel.Message = GeneralMessagesEN.SaveSubCategorySuccess;
            }
            else
            {
                returnModel.Error = true;
                returnModel.Message = GeneralMessagesEN.SaveSubCategoryAlreadyExists;
            }

            return returnModel;
        }
    }
}
