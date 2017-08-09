using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Data.Config
{
    public class UserConfig:EntityTypeConfiguration<UserEntity>
    {
        public UserConfig()
        {
            ToTable("Users");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.LoginName).HasColumnType("varchar").IsRequired().HasMaxLength(20);
            Property(item => item.Email).HasColumnType("varchar").IsRequired().HasMaxLength(36);
            Property(item => item.Password).HasColumnType("varchar").IsRequired().HasMaxLength(36);
            Property(item => item.RealName).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.Status).IsRequired();
        }
    }
}
