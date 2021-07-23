using System;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace GenHostTest
{
	public interface IDataProcessor			
	{
		byte[] ProcessBuffer(byte[] data, int size);

		Task<byte[]> ProcessBufferAsync(byte[] data, int size)
		{
			return Task<byte[]>.Run(() => ProcessBuffer(data, size));
		}
	}

    public class Worker : BackgroundService
    {
		private readonly IDataProcessor _processor;
		private readonly string _channel;

        public Worker(IDataProcessor processor, IConfiguration config)
        {
            _processor = processor;
			_channel = config.GetValue<string>("ServerConfig:PipeName") ?? "ghtpipe";
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
			using var server = new NamedPipeServerStream(_channel, PipeDirection.InOut);
			Console.WriteLine($"{_channel} service available");
			byte[] buffer = new byte[80];
			while(!stoppingToken.IsCancellationRequested)
			{
				await server.WaitForConnectionAsync(stoppingToken);
				int n = await server.ReadAsync(buffer, 0, buffer.Length, stoppingToken);
				byte[] result = await _processor.ProcessBufferAsync(buffer, n);
				await server.WriteAsync(result, 0, result.Length, stoppingToken);
				server.Disconnect();
			}
        }

    }
}

