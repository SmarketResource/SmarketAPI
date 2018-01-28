using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.CommomModels
{
    public class EmployeeModel
    {

        public Guid     UserId      { get; set; }

        public Guid     CommerceId  { get; set; }

        public string   Name        { get; set; }

        public string   LastName    { get; set; }

        public string   CPF         { get; set; }

        public int      RoleId      { get; set; }

        public string   Avatar      { get; set; }
    }
}
