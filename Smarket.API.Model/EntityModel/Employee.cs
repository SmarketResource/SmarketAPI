using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Context
{
    [Table("Employee")]
    public partial class Employee : EntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Phones = new HashSet<Phones>();
        }

        [Key]
        public Guid UserId { get; set; }

        public Guid CommerceId { get; set; }

        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string CPF { get; set; }

        public string Avatar { get; set; }

        public virtual Users Users { get; set; }

        public virtual Commerce Commerce { get; set; }

        public virtual EmployeeRole EmployeeRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Phones> Phones { get; set; }

    }
}
