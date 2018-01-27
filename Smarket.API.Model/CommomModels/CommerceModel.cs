using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.CommomModels
{
    public class CommerceModel
    {

        public Guid     UserId                  { get; set; }

        public string   CNPJ                    { get; set; }

        public string   SocialName              { get; set; }

        public string   FantasyName             { get; set; }

        public string   StateRegistration       { get; set; }

        public string   MunicipalRegistration   { get; set; }

        public string   Banner                  { get; set; }

        public string   Logo                    { get; set; }
    }
}
