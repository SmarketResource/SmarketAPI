using Smarket.API.Model.CommomModels;
using System.Collections.Generic;

namespace Smarket.API.Model.Returns
{
    public class LotReturn : BaseReturn
    {
        public LotReturn()
        {
            Lots = new List<LotModel>();
        }

        public IList<LotModel> Lots { get; set; }
    }
}
