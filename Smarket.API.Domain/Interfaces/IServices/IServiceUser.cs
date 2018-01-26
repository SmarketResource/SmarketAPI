using Smarket.API.Model.Commands;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceUser
    {
        UserReturn GetUsers();

        BaseReturn SaveUser(Users newUser);
    }
}
