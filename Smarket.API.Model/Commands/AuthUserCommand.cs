using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Commands
{
    public class AuthUserCommand
    {

        public string UserLogin { get; set; }
        public string UserPass { get; set; }

    }
}
