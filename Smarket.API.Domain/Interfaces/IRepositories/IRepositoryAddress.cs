using Smarket.API.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryAddress : IRepositoryBase<Address>
    {
        Address AddAddress(Address address);
    }
}
