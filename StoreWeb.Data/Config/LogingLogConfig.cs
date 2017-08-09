using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Data.Config
{
    public class LogingLogConfig : EntityTypeConfiguration<LogingLogEntity>
    {
        public LogingLogConfig()
        {
            ToTable("LogingLog");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.LoginName).HasColumnType("varchar").IsRequired().HasMaxlength(20);
            Property(item => item.UserId).IsRequired();
            Property(item => item.IP).HasColumnType("varchar").IsOptional().HasMaxLength(15);
            Property(item => item.Mac).HasColumnType("varchar").IsOptional().HasMaxLength(40);
        }
    }
}
