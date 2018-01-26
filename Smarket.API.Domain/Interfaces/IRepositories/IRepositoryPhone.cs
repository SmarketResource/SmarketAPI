using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryPhone : IRepositoryBase<Phones>
    {
        Phones AddPhone(Phones phone);
    }
}
