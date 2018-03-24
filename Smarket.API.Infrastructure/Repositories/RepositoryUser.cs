using AutoMapper;
using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.Returns;
using System.Collections.Generic;
using System.Linq;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryUser : RepositoryBase<Users>, IRepositoryUser
    {

        private readonly SmarketContext _context;

        public RepositoryUser(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public Users AddUser(Users user)
        {
            _context.Users.Add(user);
            return user;
        }

        public UserReturn GetUsers()
        {
            var users = _context.Users.Select(s => s).ToList();

            var returnModel = new UserReturn{ Users = Mapper.Map<List<Users>, List<UserModel>>(users) };

            return returnModel;
        }
    }
}
