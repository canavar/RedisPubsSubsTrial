using StackExchange.Redis;
using System;

namespace RedisPubsSubsTrial
{
    static class Program
    {
        // Original Code From : https://github.com/taswar/RedisForNetDevelopers/tree/master/9.RedisPubSub/RedisPubSub

        static void Main(string[] args)
        {
            var redis = new RedisStore();

            var subscriber = redis.GetSubscriber();
            var publisher = redis.GetSubscriber();

            SimpleScenario simpleScenario = new SimpleScenario(subscriber, publisher);
            simpleScenario.Run();

            PatternScenario patternScenario = new PatternScenario(subscriber, publisher);
            patternScenario.Run();

            LiteralScenario literalScenario = new LiteralScenario(subscriber, publisher);
            literalScenario.Run();

            AutoScenario autoScenario = new AutoScenario(subscriber, publisher);
            autoScenario.Run();

            UnsubscribeScenario unsubscribeScenario = new UnsubscribeScenario(subscriber, publisher);
            unsubscribeScenario.Run();

            Console.ReadKey();
        }
    }
}
