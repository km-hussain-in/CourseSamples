using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BasicWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddSingleton<Dictionary<string, int>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
			app.UseMiddleware<Counting>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context =>
                    Task.Run(() => context.Response.Redirect("/Greet"))
                );
				endpoints.MapGet("/Greet/{person=Visitor}", Greeter);
            });
        }

		private static async Task Greeter(HttpContext context)
		{
			var visitor = context.GetRouteValue("person");
			await context.Response.WriteAsync
			($@"
				<html>
					<head><title>BasicWebApp</title></head>
					<body>
						<h1>Welcome {visitor}</h1>
						<b>Current Time: </b>{DateTime.Now}
						<p>
							<b>Number of Greetings: </b>{context.Items["hits"]}
						</p>
					</body>
				</html>
			");
		}

		public class Counting
		{
			Dictionary<string, int> _counters;
			RequestDelegate _next;

			public Counting(Dictionary<string, int> counters, RequestDelegate next) => (_counters, _next) = (counters, next);

			public async Task Invoke(HttpContext context)
			{
				string id = context.Request.Path.Value;
				lock(_counters)
				{
					_counters.TryGetValue(id, out int count);
					context.Items["hits"] = _counters[id] = ++count;
				}
				await _next.Invoke(context);
			}

		}
    }

}
