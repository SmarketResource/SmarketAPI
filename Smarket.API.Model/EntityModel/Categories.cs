﻿using Smarket.API.Model.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarket.API.Model.EntityModel
{
    [Table("Categories")]
    public partial class Categories : EntityBase 
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public string Image { get; set; }
    }
}
