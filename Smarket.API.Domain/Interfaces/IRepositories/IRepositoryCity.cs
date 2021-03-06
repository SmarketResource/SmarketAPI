﻿using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IRepositories
{
    public interface IRepositoryCity : IRepositoryBase<Cities>
    {
        CityReturn GetCities();

        CityReturn GetCitiesByStateId(int stateId);

        Cities AddCity(Cities city);
    }
}
