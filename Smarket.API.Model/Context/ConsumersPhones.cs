using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.Context
{
    [Table("ConsumersPhones")]
    public class ConsumersPhones : EntityBase
    {
        //[Column(Order = 1), Key, ForeignKey("UserId")]
        //public Guid UserId { get; set; }

        //[Column(Order = 2), Key, ForeignKey("PhoneId")]
        //public Guid PhoneId { get; set; }
    }
}
