using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RedisMasterSlave.BackgroundTasks
{
    public class RedisSubscriber : BackgroundService
    {
        private readonly IConnectionMultiplexer _connectionMultiplexer;

        public RedisSubscriber(IConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var subsriber = _connectionMultiplexer.GetSubscriber();
            return subsriber.SubscribeAsync("messager", ((ChannelMessage, value) =>
            {
                Console.WriteLine($"this message content was : {value}");
            }));
        }
    }
}
