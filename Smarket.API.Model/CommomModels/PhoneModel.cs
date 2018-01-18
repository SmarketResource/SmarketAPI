using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.CommomModels
{
    public class PhoneModel
    {

        public Guid     PhoneId     { get; set; }

        public int      TypeUserId  { get; set; }

        public string   AreaCode    { get; set; }

        public string   Number      { get; set; }


    }
}
