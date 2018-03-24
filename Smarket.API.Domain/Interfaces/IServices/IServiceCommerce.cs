using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceCommerce
    {
        CommerceReturn GetCommerces();

        BaseReturn SaveCommerce(Commerce newCommerce);
    }
}
