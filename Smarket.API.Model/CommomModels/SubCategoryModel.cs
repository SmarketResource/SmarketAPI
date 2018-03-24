using System;

namespace Smarket.API.Model.CommomModels
{
    public class SubCategoryModel
    {
        public Guid SubCategoryId { get; set; }

        public Guid CategoryId { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

    }
}
