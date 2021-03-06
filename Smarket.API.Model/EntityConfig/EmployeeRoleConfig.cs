﻿using Smarket.API.Model.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smarket.API.Model.EntityConfig
{
    public class EmployeeRoleConfig : EntityTypeConfiguration<EmployeeRole>
    {

        public EmployeeRoleConfig()
        {
            HasKey(x => x.RoleId);
            Property(x => x.RoleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Description).IsRequired();
        }
    }
}
