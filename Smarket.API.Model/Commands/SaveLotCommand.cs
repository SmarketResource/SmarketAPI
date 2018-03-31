using System;

namespace Smarket.API.Model.Commands
{
    public class SaveLotCommand
    {
        public string Description { get; set; }

        public int Amount { get; set; }

        public decimal UnitPrice { get; set; }

        public DateTime ExpirationDate { get; set; }

        public Guid MarketId { get; set; }

        public Guid ProductId { get; set; }

    }
}
