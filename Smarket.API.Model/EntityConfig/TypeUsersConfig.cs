using Smarket.API.Model.Context;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class TypeUsersConfig : EntityTypeConfiguration<TypeUsers>
    {

        public TypeUsersConfig()
        {
            HasKey(x => x.TypeUserId);
            Property(x => x.TypeUserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).IsRequired();
            HasMany(x => x.Users).WithRequired(x => x.TypeUsers);
        }
    }
}
