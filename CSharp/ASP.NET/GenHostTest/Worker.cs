using System;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace GenHostTest
{
	public interface IDataProcessor			
	{
		Task<byte[]> ProcessBufferAsync(byte[] data, int size);
	}

    public class Worker : BackgroundService
    {
		private readonly IDataProcessor _processor;

        public Worker(IDataProcessor processor)
        {
            _processor = processor;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
			using var server = new NamedPipeServerStream("ghtpipe", PipeDirection.InOut);
			Console.WriteLine("Service started...");
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

