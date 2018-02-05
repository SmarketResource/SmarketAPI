using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryAddress : RepositoryBase<Address>, IRepositoryAddress
    {

        private readonly SmarketContext _context;

        public RepositoryAddress(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public Address AddAddress(Address address)
        {
            _context.Address.Add(address);

            return address;
        }
    }
}
