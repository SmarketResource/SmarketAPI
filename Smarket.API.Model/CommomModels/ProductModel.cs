using System;

namespace Smarket.API.Model.CommomModels
{
    public class ProductModel
    {

        public Guid     ProductId       { get; set; }

        public Guid     SubCategoryId   { get; set; }

        public Guid     MarketId        { get; set; }

        public string   Description     { get; set; }

        public string   Image           { get; set; }

    }
}
