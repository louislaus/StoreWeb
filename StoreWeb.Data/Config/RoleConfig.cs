using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Data.Config
{
    public class RoleConfig:EntityTypeConfiguration<RoleEntity>
    {
        public RoleConfig()
        {
            ToTable("Roles");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(item => item.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.Description).HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
        }
    }
}
