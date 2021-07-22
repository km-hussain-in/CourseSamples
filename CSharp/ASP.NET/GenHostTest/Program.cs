using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenHostTest
{
	class StockExchange : IMessageProducer
	{
		Random rdm = new ();

		public (string, int) ProduceMessage(int id)
		{
			string[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
			int i = id % symbols.Length;
			double p = 0.01 * rdm.Next(1000, 10000);
			return ($"{symbols[i]} = {p:0.00}", 5000);
		}
	}

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
					services.AddTransient<IMessageProducer, StockExchange>();
                    services.AddHostedService<Worker>();
                });
    }
}
