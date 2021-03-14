using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisPubsSubsTrial
{
    public class UnsubscribeScenario
    {
        private readonly ISubscriber subscriber;
        private readonly ISubscriber publisher;

        public UnsubscribeScenario(ISubscriber subscriber, ISubscriber publisher)
        {
            this.subscriber = subscriber;
            this.publisher = publisher;
        }

        public void Run()
        {
            subscriber.Unsubscribe("a*c");
            var count = publisher.Publish("abc", "Hello there I am a abc message"); //no one listening anymore
            Console.WriteLine($"Number of listeners for a*c {count}");
        }
    }
}
