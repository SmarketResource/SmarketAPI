using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Context
{
    [Table("EmployeeRole")]
    public partial class EmployeeRole : EntityBase
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

    }
}
