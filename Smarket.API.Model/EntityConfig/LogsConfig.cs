using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.EntityConfig
{
    public class LogsConfig : EntityTypeConfiguration<Logs>
    {

        public LogsConfig()
        {
            HasKey(x => x.LogId);
            Property(x => x.LogId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Message).IsRequired();
            Property(x => x.LogDate).IsRequired();
        }

    }
}
