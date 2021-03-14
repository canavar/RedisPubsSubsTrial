using StackExchange.Redis;
using System;

namespace RedisPubsSubsTrial
{
    public class AutoScenario
    {
        private readonly ISubscriber subscriber;
        private readonly ISubscriber publisher;

        public AutoScenario(ISubscriber subscriber, ISubscriber publisher)
        {
            this.subscriber = subscriber;
            this.publisher = publisher;
        }

        public void Run()
        {
            //Auto pattern match with a message
            subscriber.Subscribe(new RedisChannel("zyx*", RedisChannel.PatternMode.Auto), (channel, message) => {
                Console.WriteLine($"[Subscriber] Got Literal pattern zyx* notification: {message}");
            });

            publisher.Publish("zyxabc", "Hello there I am a zyxabc message");
            publisher.Publish("zyx1234", "Hello there I am a zyxabc message");
        }
    }
}
