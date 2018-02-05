using Smarket.API.Model.CommomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Returns
{
    public class CityReturn : BaseReturn
    {

        public CityReturn()
        {
            Cities = new List<CityModel>();
        }

        public List<CityModel> Cities { get; set; }

    }
}
