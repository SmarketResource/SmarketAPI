using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;

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
