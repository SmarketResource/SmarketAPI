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
    public class CommerceConfig : EntityTypeConfiguration<Commerce>
    {

        public CommerceConfig()
        {
            HasKey(x => x.CommerceId);
            Property(x => x.CommerceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SocialName).IsRequired();
            Property(x => x.FantasyName).IsRequired();
            Property(x => x.CNPJ).IsRequired();
            Property(x => x.MunicipalRegistration).IsOptional();
            Property(x => x.StateRegistration).IsOptional();
            Property(x => x.Banner).IsOptional();
            Property(x => x.Logo).IsOptional();

            HasMany(x => x.Employee)
                .WithRequired(x => x.Commerce)
                .HasForeignKey(x => x.CommerceId);

        }
    }
}
