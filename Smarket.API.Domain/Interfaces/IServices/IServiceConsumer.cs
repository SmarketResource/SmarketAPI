using Smarket.API.Model.Commands;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceConsumer
    {

        ConsumerReturn GetConsumers();

        BaseReturn SaveConsumer(SaveConsumerCommand command);
    }
}
