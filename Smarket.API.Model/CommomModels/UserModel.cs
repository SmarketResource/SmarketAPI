using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.CommomModels
{
    public class UserModel
    {
        public Guid         UserId          { get; set; }
        
        public int          TypeUserId      { get; set; }

        public string       UserLogin       { get; set; }

        public string       UserPass        { get; set; }

        public DateTime?    UserLastAccess  { get; set; }

    }
}
