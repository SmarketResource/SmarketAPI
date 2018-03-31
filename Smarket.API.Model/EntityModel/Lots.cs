using Smarket.API.Model.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarket.API.Model.EntityModel
{
    [Table("Lots")]
    public partial class Lots : EntityBase
    {
        [Key]
        public Guid LotId { get; set; }

        public Guid ProductId { get; set; }

        public Guid MarketId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [ForeignKey("MarketId")]
        public virtual Market Market { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }


    }
}
