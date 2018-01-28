using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceCommerce
    {
        CommerceReturn GetCommerces();

        BaseReturn SaveCommerce(Commerce commerce);
    }
}
