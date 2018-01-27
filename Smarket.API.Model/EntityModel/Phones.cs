namespace Smarket.API.Model.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phones")]
    public partial class Phones : EntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phones()
        {
            Consumers = new HashSet<Consumers>();
        }

        [Key]
        public Guid PhoneId { get; set; }

        public int TypePhoneId { get; set; }

        [Required]
        [StringLength(10)]
        public string AreaCode { get; set; }

        [Required]
        [StringLength(20)]
        public string Number { get; set; }

        public virtual TypePhone TypePhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Consumers> Consumers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
