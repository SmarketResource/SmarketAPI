using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.EntityModel
{
    [Table("Address")]
    public class Address : EntityBase
    {
        [Key]
        public Guid AddressId { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(10)]
        public string Number { get; set; }

        [StringLength(50)]
        public string Complement { get; set; }

        [StringLength(100)]
        public string Neighborhood { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        public int CityId { get; set; }

        public int StateId { get; set; }

        public virtual Cities Cities { get; set; }

        public virtual States States { get; set; }
        
    }
}
