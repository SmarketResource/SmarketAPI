using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Commands
{
    public class SavePhoneCommand
    {

        public int      TypePhoneId   { get; set; }

        public string   AreaCode      { get; set; }

        public string   PhoneNumber   { get; set; }

    }
}
