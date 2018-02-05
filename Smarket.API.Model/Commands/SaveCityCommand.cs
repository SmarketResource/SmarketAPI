using Smarket.API.Model.CommomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Commands
{
    public class SaveCityCommand
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Description { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
