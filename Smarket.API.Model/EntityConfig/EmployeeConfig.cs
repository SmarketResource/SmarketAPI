using Smarket.API.Model.Context;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class EmployeeConfig : EntityTypeConfiguration<Employee>
    {

        public EmployeeConfig()
        {
            HasKey(x => x.UserId);
            Property(x => x.Name).IsRequired();
            Property(x => x.LastName).IsRequired();
            Property(x => x.RoleId).IsRequired();
            
            HasMany(x => x.Phones).WithMany(x => x.Employee).Map(ap =>
            {
                ap.MapLeftKey("UserId");
                ap.MapRightKey("PhoneId");
                ap.ToTable("CommerceEmployeePhones");
            });

            HasRequired(x => x.Users).WithRequiredDependent();
            //HasRequired(x => x.Commerce).WithRequiredPrincipal();
        }

    }
}
