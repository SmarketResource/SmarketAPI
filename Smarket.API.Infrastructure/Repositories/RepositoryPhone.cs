﻿using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.Context;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryPhone : RepositoryBase<Phones>, IRepositoryPhone
    {

        private readonly SmarketContext _context;

        public RepositoryPhone(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public Phones AddPhone(Phones phone)
        {
            _context.Phones.Add(phone);

            return phone;
        }
    }
}
