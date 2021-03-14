using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisPubsSubsTrial
{
    public class SimpleScenario
    {
        private readonly ISubscriber subscriber;
        private readonly ISubscriber publisher;

        public SimpleScenario(ISubscriber subscriber, ISubscriber publisher)
        {
            this.subscriber = subscriber;
            this.publisher = publisher;
        }

        public void Run()
        {
            //first subscribe, until we publish
            //subscribe to a test message
            subscriber.Subscribe("SimpleScenario", (channel, message) => {
                Console.WriteLine($"[Subscriber] Got notification: {message}");
            });

            //pubish to test channel a message
            var count = publisher.Publish("SimpleScenario", "Message for the simple scenario");
            Console.WriteLine($"Number of subscribers for SimpleScenario {count}");

            //no message being published to it so it will not receive any previous messages
            subscriber.Subscribe("SimpleScenario", (channel, message) => {
                Console.WriteLine($"[Subscriber] I am a late subscriber Got notification: {message}");
            });

        }
    }
}
