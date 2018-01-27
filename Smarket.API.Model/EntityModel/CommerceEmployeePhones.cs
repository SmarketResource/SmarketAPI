using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Smarket.API.Model.Context
{
    [Table("CommerceEmployeePhones")]
    public partial class CommerceEmployeePhones : EntityBase
    {
        [Column(Order = 1), Key, ForeignKey("UserId")]
        public Guid UserId { get; set; }

        [Column(Order = 2), Key, ForeignKey("PhoneId")]
        public Guid PhoneId { get; set; }

    }
}
