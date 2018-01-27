using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarket.API.Model.Context
{

    [Table("Commerce")]
    public partial class Commerce : EntityBase
    {

        public Commerce()
        {
           Employee = new HashSet<Employee>();

        }

        [Key]
        public Guid CommerceId { get; set; }

        [Required]
        [StringLength(50)]
        public string CNPJ { get; set; }

        [Required]
        [StringLength(50)]
        public string SocialName { get; set; }

        [Required]
        [StringLength(50)]
        public string FantasyName { get; set; }

        public string StateRegistration { get; set; }

        public string MunicipalRegistration { get; set; }

        public string Banner { get; set; }

        public string Logo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }

    }
}
