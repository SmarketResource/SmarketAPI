using Smarket.API.Model.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarket.API.Model.EntityModel
{
    [Table("Products")]
    public partial class Products : EntityBase
    {
        [Key]
        public Guid ProductId { get; set; }

        public Guid SubCategoryId { get; set; }

        public Guid MarketId { get; set; }

        public Guid BrandId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public string Image { get; set; }

        [ForeignKey("SubCategoryId")]
        public virtual SubCategories SubCategories { get; set; }

        [ForeignKey("MarketId")]
        public virtual Market Market { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brands Brand { get; set; }

    }
}
