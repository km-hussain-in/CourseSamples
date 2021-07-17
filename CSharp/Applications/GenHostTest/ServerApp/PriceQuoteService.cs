using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace ServerApp
{
	public interface IQuotePrice
	{
		double? GetUnitPrice(string item);
	}

	public class PriceQuoteService : BackgroundService
	{
		private IQuotePrice _model;

		public PriceQuoteService(IQuotePrice model) => _model = model;

		protected override async Task ExecuteAsync(CancellationToken state)
		{
			var server = new TcpListener(IPAddress.Any, 6001);
			server.Start();
			Console.WriteLine("Server started on local TCP port 6001");
			while(!state.IsCancellationRequested)
			{
				var client = await server.AcceptTcpClientAsync();
				var reader = new StreamReader(client.GetStream());
				var writer = new StreamWriter(client.GetStream());
				writer.AutoFlush = true;
				try
				{
					string item = await reader.ReadLineAsync();
					double? price = _model.GetUnitPrice(item);
					if(price != null)
						await writer.WriteLineAsync(price.Value.ToString("0.00"));
				}
				catch {}
				writer.Close();
				reader.Close();
				client.Close();
			}
		}
	}
}

