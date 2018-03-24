using Smarket.API.Model.EntityModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class BrandsConfig : EntityTypeConfiguration<Brands>
    {

        public BrandsConfig()
        {
            HasKey(x => x.BrandId);
            Property(x => x.BrandId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).IsRequired();
            Property(x => x.Logo).IsOptional();
        }
    }
}
