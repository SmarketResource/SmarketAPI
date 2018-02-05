using System;

namespace Smarket.API.Model.CommomModels
{
    public class MarketModel
    {
        public Guid     MarketId                { get; set; }

        public string   CNPJ                    { get; set; }

        public string   SocialName              { get; set; }

        public string   FantasyName             { get; set; }

        public string   StateRegistration       { get; set; }

        public string   MunicipalRegistration   { get; set; }

        public string   Banner                  { get; set; }

        public string   Logo                    { get; set; }
    }
}
