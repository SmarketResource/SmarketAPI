using Smarket.API.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.EntityConfig
{
    public class AddressConfig : EntityTypeConfiguration<Address>
    {

        public AddressConfig()
        {
            HasKey(x => x.AddressId);
            Property(x => x.AddressId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Street).IsRequired();
            Property(x => x.Number).IsRequired();
            Property(x => x.Neighborhood).IsRequired();
            Property(x => x.Complement).IsOptional();
            HasRequired(x => x.States);
            HasRequired(x => x.Cities);

        }
    }
}
