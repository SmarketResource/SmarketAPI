using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryCity : RepositoryBase<Cities>, IRepositoryCity
    {

        private readonly SmarketContext _context;

        public RepositoryCity(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public Cities AddCity(Cities city)
        {
            _context.Cities.Add(city);

            return city;
        }
    }
}
