using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryBrand : IRepositoryBase<Brands>
    {
        BrandReturn GetBrands();

        BrandReturn GetBrandById(Guid id);

        BrandReturn GetBrandByDescription(string description);

        Brands AddBrand(Brands brand);
    }
}
