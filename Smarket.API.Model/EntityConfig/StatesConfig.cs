using Smarket.API.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.EntityConfig
{
    public class StatesConfig : EntityTypeConfiguration<States>
    {

        public StatesConfig()
        {
            HasKey(x => x.StateId);
            Property(x => x.Description).IsRequired();
            Property(X => X.Initials).IsRequired();

            HasMany(x => x.Cities)
                .WithRequired(x => x.States)
                .HasForeignKey(x => x.StateId);
        }
    }
}
