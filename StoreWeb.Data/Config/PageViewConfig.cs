﻿using StoreWeb.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StoreWeb.Data.Config
{
    public class PageViewConfig:EntityTypeConfiguration<PageViewEntity>
    {
        public PageViewConfig()
        {
            ToTable("PageView");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(item => item.UserId);
            Property(item => item.LoginName).HasColumnType("varchar").HasMaxLength(20);
            Property(item => item.Url).HasColumnType("varchar").IsRequired().HasMaxLength(300);
        }
    }
}
