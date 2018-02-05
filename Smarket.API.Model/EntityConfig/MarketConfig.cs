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
    public class MarketConfig : EntityTypeConfiguration<Market>
    {

        public MarketConfig()
        {
            HasKey(x => x.MarketId);
            Property(x => x.MarketId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.SocialName).IsRequired();
            Property(x => x.FantasyName).IsRequired();
            Property(x => x.CNPJ).IsRequired();
            Property(x => x.MunicipalRegistration).IsOptional();
            Property(x => x.StateRegistration).IsOptional();
            Property(x => x.Banner).IsOptional();
            Property(x => x.Logo).IsOptional();
            Property(x => x.AddressId).IsRequired();


            HasMany(x => x.MarketEmployee)
                .WithRequired(x => x.Market)
                .HasForeignKey(x => x.MarketId);
        }
    }
}
