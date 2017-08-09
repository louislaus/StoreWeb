using StoreWeb.Data.Config;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext() : base("storeWeb") { }
        public StoreContext(string connectionString) : base(connectionString) { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Configurations.Add(new UserConfig());
            modelBuilder.Configurations.Add(new MenuConfig());
            modelBuilder.Configurations.Add(new RoleConfig());
            modelBuilder.Configurations.Add(new RoleMenuConfig());
            modelBuilder.Configurations.Add(new UserRoleConfig());
            modelBuilder.Configurations.Add(new LogingLogConfig());
            modelBuilder.Configurations.Add(new PageViewConfig());
        }
    }
}
