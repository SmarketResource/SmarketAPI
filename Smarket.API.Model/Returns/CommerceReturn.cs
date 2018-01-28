using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Returns
{
    public class CommerceReturn : BaseReturn
    {

        public CommerceReturn()
        {
            Commerces = new List<CommerceModel>();
        }

        public List<CommerceModel> Commerces { get; set; }
    }
}
