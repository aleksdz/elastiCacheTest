using System;
using Enyim.Caching;
using Amazon.ElastiCacheCluster;

namespace ElastiCacheTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ElastiCacheClusterConfig("memcachedcluster.jqauhs.cfg.euw1.cache.amazonaws.com",11211);
            var client = new MemcachedClient(config);

            client.Store(Enyim.Caching.Memcached.StoreMode.Set, "key", "value");

            Console.WriteLine(client.Get("key"));
        }
    }
}
