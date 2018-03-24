using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceConsumer
    {
        ConsumerReturn GetConsumers();

        BaseReturn SaveConsumer(Consumers newConsumer);
    }
}
