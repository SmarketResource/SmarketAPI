using Smarket.API.Model.CommomModels;
using System.Collections.Generic;

namespace Smarket.API.Model.Returns
{
    public class SubCategoryReturn : BaseReturn
    {

        public SubCategoryReturn()
        {
            SubCategories = new List<SubCategoryModel>();
        }

        public IList<SubCategoryModel> SubCategories { get; set; }

    }
}
