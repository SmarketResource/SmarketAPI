using AutoMapper;
using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryBrand : RepositoryBase<Brands>, IRepositoryBrand
    {

        private readonly SmarketContext _context;

        public RepositoryBrand(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public Brands AddBrand(Brands brand)
        {
            _context.Brands.Add(brand);

            return brand;
        }

        public BrandReturn GetBrandByDescription(string description)
        {
            var brands = _context.Brands.Where(b => b.Description == description).ToList();

            var returnModel = new BrandReturn { Brands = Mapper.Map<List<Brands>, List<BrandModel>>(brands) };

            return returnModel;
        }

        public BrandReturn GetBrandById(Guid id)
        {

            var brands = _context.Brands.Where(b => b.BrandId == id).ToList();

            var returnModel = new BrandReturn { Brands = Mapper.Map<List<Brands>, List<BrandModel>>(brands) };

            return returnModel;
        }

        public BrandReturn GetBrands()
        {
            var brands = _context.Brands.ToList();

            var returnModel = new BrandReturn { Brands = Mapper.Map<List<Brands>, List<BrandModel>>(brands) };

            return returnModel;
        }
    }
}
