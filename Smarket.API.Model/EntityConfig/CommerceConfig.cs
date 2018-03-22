using Smarket.API.Model.Context;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

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

            HasMany(x => x.CommerceEmployee)
                .WithRequired(x => x.Commerce)
                .HasForeignKey(x => x.CommerceId);

        }
    }
}
