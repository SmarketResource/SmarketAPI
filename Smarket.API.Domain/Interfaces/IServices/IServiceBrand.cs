using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceBrand
    {
        BrandReturn GetBrands();

        BrandReturn GetBrandById(Guid id);

        BrandReturn GetBrandByDescription(string description);

        BaseReturn SaveBrand(Brands brand);

    }
}
