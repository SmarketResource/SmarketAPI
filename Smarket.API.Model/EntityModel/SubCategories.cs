using Smarket.API.Model.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarket.API.Model.EntityModel
{
    [Table("SubCategories")]
    public partial class SubCategories : EntityBase
    {

        [Key]
        public Guid SubCategoryId { get; set; }

        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public string Image { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Categories Categories { get; set; }

    }
}
