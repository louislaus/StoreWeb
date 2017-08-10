using StoreWeb.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Data.Config
{
    public class UserRoleConfig:EntityTypeConfiguration<UserRoleEntity>
    {
        public UserRoleConfig()
        {
            ToTable("UserRole");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.RoleId).IsRequired();
            Property(item => item.UserId).IsRequired();
            HasRequired(item => item.User).WithMany(item => item.UserRoles).HasForeignKey(item => item.UserId);
        }
    }
}
