using Smarket.API.Model.CommomModels;
using System.Collections.Generic;

namespace Smarket.API.Model.Returns
{
    public class CategoryReturn : BaseReturn
    {

        public CategoryReturn()
        {
            Categories = new List<CategoryModel>();
        }

        public IList<CategoryModel> Categories { get; set; }
    }
}
