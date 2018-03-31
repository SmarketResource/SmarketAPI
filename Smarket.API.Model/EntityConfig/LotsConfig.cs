using Smarket.API.Model.EntityModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Smarket.API.Model.EntityConfig
{
    public class LotsConfig : EntityTypeConfiguration<Lots>
    {

        public LotsConfig()
        {
            HasKey(x => x.LotId);
            Property(x => x.LotId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).IsRequired();
            Property(x => x.ExpirationDate).IsRequired();
            Property(x => x.Amount).IsRequired();
            Property(x => x.UnitPrice).IsRequired();
            HasRequired(x => x.Products);
            HasRequired(x => x.Market); 

        }
    }
}
