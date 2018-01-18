using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Returns
{
    public class BaseReturn
    {
        public BaseReturn()
        {
            Error = false;
        }
        public bool Error { get; set; }
        public string Message { get; set; }
    }
}
