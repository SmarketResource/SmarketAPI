using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Returns
{
    public class LoginReturn : BaseReturn
    { 
        public string Token { get; set; }
    }

    public class LoginReturnModel
    {
        public Guid     UserId  { get; set; }
        public DateTime Date    { get; set; }
    }
}
