using Smarket.API.Model.Context;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class TypePhoneConfig : EntityTypeConfiguration<TypePhone>
    {

        public TypePhoneConfig()
        {
            HasKey(x => x.TypePhoneId);
            Property(x => x.TypePhoneId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).IsRequired();
        }

    }
}
