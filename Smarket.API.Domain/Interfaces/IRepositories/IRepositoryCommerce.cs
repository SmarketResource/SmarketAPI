using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryCommerce : IRepositoryBase<Commerce>
    {

        CommerceReturn GetCommerces();

    }
}
