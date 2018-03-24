using System;

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
