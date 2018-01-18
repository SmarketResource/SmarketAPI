using Smarket.API.Model.CommomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Returns
{
    public class ConsumerReturn :  BaseReturn
    {

        public ConsumerReturn()
        {
            Consumers = new List<ConsumerModel>();
        }

        public List<ConsumerModel> Consumers { get; set; }
    }
}
