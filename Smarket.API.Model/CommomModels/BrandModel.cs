using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.CommomModels
{
    public class BrandModel
    {
        public Guid BrandId         { get; set; }

        public string Description   { get; set; }

        public string Logo          { get; set; }

    }
}
