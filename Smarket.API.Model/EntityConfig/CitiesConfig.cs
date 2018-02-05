using Smarket.API.Model.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.EntityConfig
{
    public class CitiesConfig : EntityTypeConfiguration<Cities>
    {
        public CitiesConfig()
        {
            HasKey(x => x.CityId);
            Property(x => x.CityId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.Description).IsRequired();
            Property(x => x.Latitude).IsRequired();
            Property(x => x.Longitude).IsRequired();
            Property(x => x.StateId).IsRequired();
        }
    }
}
