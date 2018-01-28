using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;

namespace Smarket.API.Service.Services
{
    public class ServiceCommerce : ServiceBase<Commerce>, IServiceCommerce
    {
        public CommerceReturn GetCommerces()
        {
            throw new System.NotImplementedException();
        }
    }
}
