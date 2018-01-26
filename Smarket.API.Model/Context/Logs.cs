namespace Smarket.API.Model.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Logs")]
    public partial class Logs : EntityBase
    {
        [Key]
        public Guid LogId { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime LogDate { get; set; }
    }
}
