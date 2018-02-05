using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Domain.Interfaces.IServices;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;

namespace Smarket.API.Service.Services
{
    public class ServiceState : ServiceBase<States>, IServiceState
    {

        private readonly IRepositoryState _repositoryState;

        public ServiceState(IRepositoryState repositoryState)
        {
            _repositoryState = repositoryState;
        }

        public StateReturn GetStates()
        {
            var returnModel = new StateReturn();

            returnModel = _repositoryState.GetStates();

            return returnModel;
        }
    }
}
