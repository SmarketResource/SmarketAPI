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
    public class ConsumersConfig : EntityTypeConfiguration<Consumers>
    {

        public ConsumersConfig()
        {
            HasKey(x => x.UserId);
            //Property(x => x.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).IsRequired();
            Property(x => x.LastName).IsRequired();
            Property(x => x.Avatar).IsOptional();
            HasRequired(x => x.Users).WithRequiredDependent();
            HasMany(x => x.Phones).WithMany(x => x.Consumers).Map(ap =>
            {
                ap.MapLeftKey("UserId");
                ap.MapRightKey("PhoneId");
                ap.ToTable("ConsumersPhones");
            });
        }

    }
}
