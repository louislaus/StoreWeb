using Memcached.ClientLibrary;

namespace StoreWeb.Core.Memcached
{
    public class MemcachedClientSingleton:Singleton<MemcachedClient>
    {
        private MemcachedClientSingleton()
        {

        }
    }
}
