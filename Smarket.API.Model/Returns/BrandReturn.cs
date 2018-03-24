using Smarket.API.Model.CommomModels;
using System.Collections.Generic;

namespace Smarket.API.Model.Returns
{
    public class BrandReturn : BaseReturn
    {
        public BrandReturn()
        {
            Brands = new List<BrandModel>();
        }

        public IList<BrandModel> Brands { get; set; }
    }
}
