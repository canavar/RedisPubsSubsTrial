using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisPubsSubsTrial
{
    public class LiteralScenario
    {
        private readonly ISubscriber subscriber;
        private readonly ISubscriber publisher;

        public LiteralScenario(ISubscriber subscriber, ISubscriber publisher)
        {
            this.subscriber = subscriber;
            this.publisher = publisher;
        }

        public void Run()
        {
            //Never a pattern match with a message
            subscriber.Subscribe(new RedisChannel("*123", RedisChannel.PatternMode.Literal), (channel, message) => {
                Console.WriteLine($"Got Literal pattern *123 notification: {message}");
            });

            publisher.Publish("*123", "Hello there I am a *123 message");
            publisher.Publish("a123", "Hello there I am a a123 message"); //message is never received due to literal pattern
        }
    }
}
