using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Data.Config
{
    public class RoleMenuConfig:EntityTypeConfiguration<RoleMenuEntity>
    {
        public RoleMenuConfig()
        {
            ToTable("RoleMenu");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(item => item.RoleId).IsRequired();
            Property(item => item.MenuId).IsRequired();
        }
    }
}
