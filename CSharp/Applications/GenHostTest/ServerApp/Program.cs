using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ServerApp
{
	public class StockExchange : IQuotePrice
	{
		Random rdm = new Random();

		public double? GetUnitPrice(string symbol)
		{
			string[] symbols = {"AMZN", "APPL", "GOGL", "MSFT", "ORCL"};
			int i = Array.IndexOf(symbols, symbol);
			if(i >= 0)
				return 0.01 * rdm.Next(1000, 10000);
			return null;
		}
	}

    class Program
    {

		static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) => 
				{
					services.AddSingleton<IQuotePrice, StockExchange>();
					services.AddHostedService<PriceQuoteService>();
				})
				.ConfigureLogging(config => config.ClearProviders());
    }
}

