using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Commands
{
    public class SaveConsumerCommand
    {
        public string   UserLogin   { get; set; }

        public string   UserPass    { get; set; }

        public string   Name        { get; set; }

        public string   LastName    { get; set; }

        public int      TypePhone   { get; set; }

        public string   AreaCode    { get; set; }

        public string   PhoneNumber { get; set; }

    }
}
