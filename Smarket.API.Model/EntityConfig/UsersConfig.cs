using Smarket.API.Model.Context;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class UsersConfig : EntityTypeConfiguration<Users>
    {

        public UsersConfig()
        {
            HasKey(x => x.UserId);
            Property(x => x.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserLogin).IsRequired();
            Property(x => x.UserPass).IsRequired();
            Property(x => x.UserLastAccess).IsOptional();
            HasRequired(x => x.TypeUsers);
        }

    }
}
