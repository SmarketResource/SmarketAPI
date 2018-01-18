using Smarket.API.Model.Returns;


namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceLogin
    {
        UserReturn Authenticate(string username, string password);

        bool CheckIfTokenIsValid(string token);
    }
}
