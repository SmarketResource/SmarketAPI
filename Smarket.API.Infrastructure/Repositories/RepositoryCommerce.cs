using AutoMapper;
using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryCommerce : RepositoryBase<Commerce>, IRepositoryCommerce
    {
        private readonly SmarketContext _context;

        public RepositoryCommerce(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public CommerceReturn GetCommerces()
        {
            //var commerce = _context.Commerce.Select(c => c).ToList();

            //var returnModel = new CommerceReturn { Commerces = Mapper.Map<List<Commerce>, List<CommerceModel>>(commerce) };

            //return returnModel;

            return null;
        }
    }
}
