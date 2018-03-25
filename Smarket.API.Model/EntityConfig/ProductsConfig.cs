using Smarket.API.Model.EntityModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class ProductsConfig : EntityTypeConfiguration<Products>
    {
        public ProductsConfig()
        {
            HasKey(x => x.ProductId);
            Property(x => x.ProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).IsRequired();
            Property(x => x.Image).IsOptional();
            HasRequired(x => x.Market);
            HasRequired(x => x.SubCategories);
        }
    }
}
