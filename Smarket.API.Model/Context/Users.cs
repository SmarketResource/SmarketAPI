namespace Smarket.API.Model.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users : EntityBase
    {
        [Key]
        public Guid UserId { get; set; }

        public int TypeUserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserLogin { get; set; }

        [Required]
        [StringLength(50)]
        public string UserPass { get; set; }

        public DateTime? UserLastAccess { get; set; }

        public virtual Consumers Consumers { get; set; }

        public virtual TypeUsers TypeUsers { get; set; }
    }
}
