using StackExchange.Redis;
using System;
using System.Configuration;

namespace RedisPubsSubsTrial
{
    public class RedisStore
    {
        private readonly Lazy<ConnectionMultiplexer> LazyConnection;
        private IDatabase RedisCache => Connection.GetDatabase();
        private ConnectionMultiplexer Connection => LazyConnection.Value;

        public RedisStore()
        {
            string connection = ConfigurationManager.AppSettings["RedisConnection"];

            LazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(connection));
        }

        public ISubscriber GetSubscriber()
        {
            return RedisCache.Multiplexer.GetSubscriber();
        }
    }
}
