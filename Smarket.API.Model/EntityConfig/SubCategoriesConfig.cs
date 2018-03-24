using Smarket.API.Model.EntityModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class SubCategoriesConfig : EntityTypeConfiguration<SubCategories>
    {
        public SubCategoriesConfig()
        {
            HasKey(x => x.SubCategoryId);
            Property(x => x.SubCategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).IsRequired();
            Property(x => x.Image).IsOptional();
            HasRequired(x => x.Categories);
        }

    }
}
