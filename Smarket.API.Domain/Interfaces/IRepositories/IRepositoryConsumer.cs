using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryConsumer : IRepositoryBase<Consumers>
    {
        Consumers AddConsumer(Consumers consumer);

        ConsumerReturn GetConsumers();
    }
}
