using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Commands
{
    public class SaveMarketCommand
    {
        #region MarketInfo's
        public string SocialName            { get; set; }

        public string FantasyName           { get; set; }

        public string MunicipalRegistration { get; set; }

        public string StateRegistration     { get; set; }

        public string CNPJ                  { get; set; }
        #endregion

        #region PhoneInfo's
        public string AreaCode              { get; set; }

        public string Number                { get; set; }

        public int TypePhoneId              { get; set; }
        #endregion

        #region EmployeeInfo's
        public string EmployeeName          { get; set; }

        public string EmployeeLastName      { get; set; }

        public string CPF                   { get; set; }

        public int EmployeeRoleId           { get; set; }

        public string UserLogin             { get; set; }

        public string UserPass              { get; set; }
        #endregion

        #region AddressInfo's
        public string Street                { get; set; }

        public string StreetNumber          { get; set; }

        public string Complement            { get; set; }

        public string Neighborhood           { get; set; }

        public string ZipCode               { get; set; }

        public int CityId                   { get; set; }

        public int StateId                  { get; set; }
        #endregion
    }
}
