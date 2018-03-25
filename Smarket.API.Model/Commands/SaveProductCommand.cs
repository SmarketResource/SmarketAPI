using System;

namespace Smarket.API.Model.Commands
{
    public class SaveProductCommand
    {
        public string Description   { get; set; }

        public Guid MarketId        { get; set; }

        public Guid SubCategoryId   { get; set; }

        public Guid BrandId         { get; set; }

    }
}
