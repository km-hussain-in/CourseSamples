using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenHostTest
{
	class XorEncoder : IDataProcessor
	{
		public byte[] ProcessBuffer(byte[] data, int size)
		{
			byte[] buffer = new byte[size];
			for(int i = 0; i < size; ++i)
				buffer[i] = (byte)(data[i] ^ '#');
			return buffer;	
		}
	}

    public class Program
    {
        public static void Main(string[] args)
        {
			if(args.Length < 2)
            	CreateHostBuilder(args).Build().Run();
			else
				ClientSupport.Run(args);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
					services.AddOptions();
					services.AddTransient<IDataProcessor, XorEncoder>();
                    services.AddHostedService<Worker>();
                });
    }
}
