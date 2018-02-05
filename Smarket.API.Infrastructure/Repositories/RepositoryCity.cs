using AutoMapper;
using Smarket.API.Domain.Interfaces.IContext;
using Smarket.API.Domain.Interfaces.IRepositories;
using Smarket.API.Model.CommomModels;
using Smarket.API.Model.Context;
using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System.Collections.Generic;
using System.Linq;

namespace Smarket.API.Infrastructure.Repositories
{
    public class RepositoryCity : RepositoryBase<Cities>, IRepositoryCity
    {

        private readonly SmarketContext _context;

        public RepositoryCity(IDbContext context) : base(context)
        {
            _context = (SmarketContext)context;
        }

        public CityReturn GetCities()
        {
            var cities = _context.Cities.ToList();

            var returnModel = new CityReturn { Cities = Mapper.Map<List<Cities>, List<CityModel>>(cities) };

            return returnModel;
        }

        public Cities AddCity(Cities city)
        {
            _context.Cities.Add(city);

            return city;
        }

        public CityReturn GetCitiesByStateId(int stateId)
        {

            var cities = _context.Cities.Where(c => c.StateId == stateId).ToList();

            var returnModel = new CityReturn { Cities = Mapper.Map<List<Cities>, List<CityModel>>(cities) };

            return returnModel;

        }
    }
}
