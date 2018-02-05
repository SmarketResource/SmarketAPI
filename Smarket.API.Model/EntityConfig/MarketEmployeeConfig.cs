using Smarket.API.Model.EntityModel;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class MarketEmployeeConfig : EntityTypeConfiguration<MarketEmployee>
    {

        public MarketEmployeeConfig()
        {
            HasKey(x => x.UserId);
            Property(x => x.Name).IsRequired();
            Property(x => x.LastName).IsRequired();
            Property(x => x.RoleId).IsRequired();
            HasRequired(x => x.Users).WithRequiredDependent();
            HasMany(x => x.Phones).WithMany(x => x.MarketEmployee).Map(ap =>
            {
                ap.MapLeftKey("UserId");
                ap.MapRightKey("PhoneId");
                ap.ToTable("MarketEmployeePhones");
            });
        }
    }
}
