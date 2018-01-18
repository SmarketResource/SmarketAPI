using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryUser : IRepositoryBase<Users>
    {
        Users AddUser(Users user);

        UserReturn GetUsers();

    }
}
