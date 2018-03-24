using System;

namespace Smarket.API.Model.Commands
{
    public class SaveSubCategoryCommand
    {
        public string Description { get; set; }

        public Guid CategoryId { get; set; }
    }
}
