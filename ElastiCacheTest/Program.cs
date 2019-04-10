using System;
using Enyim.Caching;
using Enyim.Caching.Memcached;
using Amazon.ElastiCacheCluster;
using StackExchange.Redis;

namespace ElastiCacheTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //string value = TestMemcached("key" , "value");
            string value = TestRedis("key", "value");

            Console.WriteLine(value);
        }

        private static string TestMemcached(string key, string value)
        {
            var config = new ElastiCacheClusterConfig("memcachecluster.jqauhs.cfg.euw1.cache.amazonaws.com", 11211);
            var client = new MemcachedClient(config);

            client.Store(StoreMode.Set, key, value);
            return (string)client.Get(key) ?? "Failed to get value";
        }

        private static string TestRedis(string key, string value)
        {
            var config = new ConfigurationOptions
            {
                EndPoints = { { "rediscluster.jqauhs.clustercfg.euw1.cache.amazonaws.com", 6379 } }
            };

            var connection = ConnectionMultiplexer.Connect(config);

            connection.GetDatabase(2).StringSet(key, value, TimeSpan.FromHours(1));
            return (string)connection.GetDatabase(2).StringGet(key) ?? "Failed to get value";
        }
    }
}
