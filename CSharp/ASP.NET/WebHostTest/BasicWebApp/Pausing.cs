using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BasicWebApp	
{
	public class Pausing
	{
		private readonly RequestDelegate _next;
		private readonly TimeSpan pause;
		private DateTime lastTime;

		public Pausing(RequestDelegate next, IConfiguration config)
		{
			_next = next;
			pause = config.GetValue<TimeSpan?>("Pausing:Interval") ?? TimeSpan.FromSeconds(10); //see appsettings.json
		}

		public async Task Invoke(HttpContext context)
		{
			var delta = lastTime + pause - DateTime.Now;
			if(delta.Ticks > 0)
				await context.Response.WriteAsync($"Busy, please try after {delta.TotalSeconds} sec...");
			else
			{
				lastTime = DateTime.Now;
				await _next.Invoke(context);
			}
		}

	}

}

