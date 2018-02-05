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
    public class RepositoryState : RepositoryBase<States>, IRepositoryState
    {

        private readonly SmarketContext _context;

        public RepositoryState(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public StateReturn GetStates()
        {
            var states = _context.States.ToList();

            var returnModel = new StateReturn { States = Mapper.Map<List<States>, List<StateModel>>(states) };

            return returnModel;
        }
    }
}
