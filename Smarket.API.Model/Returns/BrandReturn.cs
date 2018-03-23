using Smarket.API.Model.CommomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Returns
{
    public class BrandReturn : BaseReturn
    {
        public BrandReturn()
        {
            Brands = new List<BrandModel>();
        }

        public List<BrandModel> Brands { get; set; }
    }
}
