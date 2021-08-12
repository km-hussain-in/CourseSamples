using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BasicWebApp	
{
	public class Pausing
	{
		private readonly RequestDelegate _next;
		private readonly int pause;
		private long lastTime;

		public Pausing(RequestDelegate next, IConfiguration config)
		{
			_next = next;
			pause = config.GetValue<int?>("Pausing:Interval") ?? 10;
		}

		public async Task Invoke(HttpContext context)
		{
			long thisTime =  DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
			if(thisTime - lastTime < pause)
				await context.Response.WriteAsync($"Busy, please try after {pause - thisTime + lastTime} sec...");
			else
			{
				lastTime = thisTime;
				await _next.Invoke(context);
			}
		}

	}

}

