using Smarket.API.Model.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarket.API.Model.EntityModel
{
    [Table("Brands")]
    public class Brands : EntityBase
    {
        [Key]
        public Guid BrandId { get; set; }

        [Required]
        public string Description { get; set; }

        public string Logo { get; set; }
    }
}
