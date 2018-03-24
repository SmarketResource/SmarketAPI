using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;

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
