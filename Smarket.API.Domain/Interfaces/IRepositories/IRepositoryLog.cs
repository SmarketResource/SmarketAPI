using Smarket.API.Model.Context;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryLog : IRepositoryBase<Logs>
    {
        void AddLog(string message);
    }
}
