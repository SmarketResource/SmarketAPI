using Smarket.API.Model.Context;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarket.API.Model.EntityModel
{
    [Table("Cities")]
    public class Cities : EntityBase
    {
        [Key]
        public int CityId { get; set; }

        public int StateId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [ForeignKey("StateId")]
        public virtual States States { get; set; }


    }
}
