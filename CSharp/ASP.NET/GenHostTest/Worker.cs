using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace GenHostTest
{
	public interface IMessageProducer
	{
		(string, int) ProduceMessage(int id);
	}

    public class Worker : BackgroundService
    {
		private readonly IMessageProducer _producer;

        public Worker(IMessageProducer producer)
        {
            _producer = producer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
			Console.WriteLine("Message store service started");
			try
			{
            	for(int i = 1; !stoppingToken.IsCancellationRequested; ++i)
            	{
					var (text, time) = _producer.ProduceMessage(i);
					StoreMessage(text);
					await Task.Delay(time, stoppingToken);
				}
			}
            catch(OperationCanceledException)
			{
				Console.WriteLine("Message store service stopped");
			}
        }

		private void StoreMessage(string text)
		{
			using var writer = new System.IO.StreamWriter("msg.store");
			writer.WriteLine(text);
		}
    }
}

