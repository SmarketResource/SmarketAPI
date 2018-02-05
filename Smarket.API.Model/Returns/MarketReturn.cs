using Smarket.API.Model.CommomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Returns
{
    public class MarketReturn : BaseReturn
    {

        public MarketReturn()
        {
            Markets = new List<MarketModel>();
        }

        public List<MarketModel> Markets { get; set; }
    }
}
