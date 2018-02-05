using Smarket.API.Model.CommomModels;
using System.Collections.Generic;

namespace Smarket.API.Model.Returns
{
    public class StateReturn : BaseReturn
    {

        public StateReturn()
        {
            States = new List<StateModel>();
        }

        public List<StateModel> States { get; set; }
    }
}
