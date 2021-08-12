using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace BasicWebApp
{
    public class Greeting
    {
		public static async Task Welcome(HttpContext context)
		{
			var visitor = context.GetRouteValue("person").ToString();
			var counter = context.RequestServices.GetService<ICounterService>();
			int count = counter.CountNext(visitor);
			await context.Response.WriteAsync
			($@"
				<html>
					<head><title>BasicWebApp</title></head>
					<body>
						<h1>Welcome {visitor}</h1>
						<p>
							<b>Number of Greetings: </b>{count}
						</p>
					</body>
				</html>
			");
		}
	}
}

