using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceLogin
    {
        UserReturn Authenticate(string username, string password);
    }
}
