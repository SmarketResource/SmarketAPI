using Smarket.API.Model.CommomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Returns
{
    public class UserReturn : BaseReturn
    {

        public UserReturn()
        {
            Users = new List<UserModel>();
        }

        public List<UserModel> Users { get; set; }

    }
}
