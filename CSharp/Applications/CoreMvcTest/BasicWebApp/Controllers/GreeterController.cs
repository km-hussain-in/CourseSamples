using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApp.Controllers
{
	public class GreeterController : ControllerBase
	{
		public IActionResult Greet(string id, [FromServices] Dictionary<string, int> counters)
		{
			int count;
			lock(counters)
			{
				counters.TryGetValue(id, out count);
				counters[id] = ++count;
			}
			var page = $@"
				<html>
					<head><title>BasicWebApp</title></head>	
					<body>
						<h1>Welcome {id}</h1>
						<b>Current Time: </b>{DateTime.Now}
						<p><b>Number of Greetings: </b>{count}</p>
					</body>
				</html>
			";
			return Content(page, "text/html");
		}
	}
}

