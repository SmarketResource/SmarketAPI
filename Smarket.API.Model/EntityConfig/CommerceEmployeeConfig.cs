using Smarket.API.Model.Context;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class CommerceEmployeeConfig : EntityTypeConfiguration<CommerceEmployee>
    {

        public CommerceEmployeeConfig()
        {
            HasKey(x => x.UserId);
            Property(x => x.Name).IsRequired();
            Property(x => x.LastName).IsRequired();
            Property(x => x.RoleId).IsRequired();
            HasRequired(x => x.Users).WithRequiredDependent();

            HasMany(x => x.Phones).WithMany(x => x.CommerceEmployee).Map(ap =>
            {
                ap.MapLeftKey("UserId");
                ap.MapRightKey("PhoneId");
                ap.ToTable("CommerceEmployeePhones");
            });

        }

    }
}
