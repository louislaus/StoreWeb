using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWeb.Data.Config
{
    internal sealed class Configuration : DbMigrationsConfiguration<StoreContext>
    {
        private readonly DateTime now = new DateTime(2017, 8, 9, 11, 46, 12);
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(StoreContext context)
        {
        }
    }
}
