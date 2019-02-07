using System;
using Enyim.Caching;
using Enyim.Caching.Memcached;
using Amazon.ElastiCacheCluster;

namespace ElastiCacheTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Setting up ElastiCacheClusterConfig");
            var config = new ElastiCacheClusterConfig("memcachedcluster.jqauhs.cfg.euw1.cache.amazonaws.com",11211);
            Console.WriteLine("Setting up MemcachedClient");
            var client = new MemcachedClient(config);

            Console.WriteLine("Storing Value");
            client.Store(StoreMode.Set, "key", "value");

            Console.WriteLine("Getting Value");
            Console.WriteLine(client.Get("key"));
            Console.WriteLine("Got Value");
        }
    }
}
