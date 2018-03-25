using Smarket.API.Model.CommomModels;
using System.Collections.Generic;

namespace Smarket.API.Model.Returns
{
    public class ProductReturn : BaseReturn
    {

        public ProductReturn()
        {
            Products = new List<ProductModel>();
        }

        public IList<ProductModel> Products { get; set; }

    }
}
