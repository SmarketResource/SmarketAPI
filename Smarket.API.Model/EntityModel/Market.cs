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
    [Table("Market")]
    public class Market : EntityBase
    {
        public Market()
        {
            MarketEmployee = new HashSet<MarketEmployee>();
        }

        [Key]
        public Guid MarketId { get; set; }
        
        public Guid AddressId { get; set; }

        [Required]
        [StringLength(50)]
        public string CNPJ { get; set; }

        [Required]
        [StringLength(50)]
        public string SocialName { get; set; }

        [Required]
        [StringLength(50)]
        public string FantasyName { get; set; }

        [StringLength(50)]
        public string StateRegistration { get; set; }

        [StringLength(50)]
        public string MunicipalRegistration { get; set; }

        public string Banner { get; set; }

        public string Logo { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MarketEmployee> MarketEmployee { get; set; }

    }
}
