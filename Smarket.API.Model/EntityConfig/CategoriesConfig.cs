using Smarket.API.Model.EntityModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class CategoriesConfig : EntityTypeConfiguration<Categories>
    {
        public CategoriesConfig()
        {
            HasKey(x => x.CategoryId);
            Property(x => x.CategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).IsRequired();
            Property(x => x.Image).IsOptional();
        }

    }
}
