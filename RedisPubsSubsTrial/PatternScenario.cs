using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisPubsSubsTrial
{
    public class PatternScenario
    {
        private readonly ISubscriber subscriber;
        private readonly ISubscriber publisher;

        public PatternScenario(ISubscriber subscriber, ISubscriber publisher)
        {
            this.subscriber = subscriber;
            this.publisher = publisher;
        }

        public void Run()
        {
            //pattern match with a message
            subscriber.Subscribe(new RedisChannel("a*c", RedisChannel.PatternMode.Pattern), (channel, message) => {
                Console.WriteLine($"[Subscriber] Got pattern a*c notification: {message}");
            });

            var count = publisher.Publish("a*c", "Hello there I am a a*c message");
            Console.WriteLine($"Number of listeners for a*c {count}");

            publisher.Publish("abc", "Hello there I am a abc message");
            publisher.Publish("a1234567890c", "Hello there I am a a1234567890c message");
            publisher.Publish("ab", "Hello I am a lost message"); //this mesage is never printed
        }
    }
}
