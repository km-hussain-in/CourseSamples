using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenHostTest
{
	class XorEncoder : IDataProcessor
	{
		public void ProcessBuffer(byte[] data, int size)
		{
			for(int i = 0; i < size; ++i)
				data[i] = (byte)(data[i] ^ '#');
		}
	}

    public class Program
    {
        public static void Main(string[] args)
        {
			if(args.Length == 0)
            	CreateHostBuilder(args).Build().Run();
			else
				ClientSupport.Run(args[0]);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
					services.AddTransient<IDataProcessor, XorEncoder>();
                    services.AddHostedService<Worker>();
                });
    }
}
