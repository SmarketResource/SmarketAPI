namespace Smarket.API.Model.Commands
{
    public class SaveCommerceCommand
    {
        public string   SocialName          { get; set; }

        public string   FantasyName         { get; set; }

        public string   CNPJ                { get; set; }

        public string   AreaCode            { get; set; }

        public string   Number              { get; set; }

        public int      TypePhoneId         { get; set; }

        public string   EmployeeName        { get; set; }
        
        public string   EmployeeLastName    { get; set; }

        public string   CPF                 { get; set; }

        public int      EmployeeRoleId      { get; set; }

        public string   UserLogin           { get; set; }

        public string   UserPass            { get; set; }
    }
}
