using System.Data.Entity;
using StoreWeb.Data.Config;

namespace StoreWeb.Data
{
    public static class InitialData
    {
        public static void Init()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, Configuration>());
        }
    }
}
