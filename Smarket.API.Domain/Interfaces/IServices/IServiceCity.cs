using Smarket.API.Model.EntityModel;
using Smarket.API.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Domain.Interfaces.IServices
{
    public interface IServiceCity
    {
        CityReturn GetCities();

        CityReturn GetCitiesByStateId(int stateId);

        BaseReturn SaveCity(Cities city);

        BaseReturn SaveListCity(List<Cities> list);
    }
}
