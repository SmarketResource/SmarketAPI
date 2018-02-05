using Smarket.API.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryCity : IRepositoryBase<Cities>
    {
        Cities AddCity(Cities city);
    }
}
