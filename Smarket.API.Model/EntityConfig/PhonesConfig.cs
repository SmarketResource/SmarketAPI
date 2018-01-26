using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.EntityConfig
{
    public class PhonesConfig : EntityTypeConfiguration<Phones>
    {

        public PhonesConfig()
        {
            HasKey(x => x.PhoneId);
            Property(x => x.PhoneId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TypePhoneId).IsRequired();
            Property(x => x.Number).IsRequired();
            Property(x => x.AreaCode).IsRequired();
        }

    }
}
