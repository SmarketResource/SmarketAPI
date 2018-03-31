using System;

namespace Smarket.API.Model.CommomModels
{
    public class LotModel
    {
        public Guid LotId { get; set; }

        public Guid ProductId { get; set; }

        public Guid MarketId { get; set; }

        public string Description { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int Amount { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
