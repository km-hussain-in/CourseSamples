using System;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApp.Controllers
{
	public class GreeterController : ControllerBase
	{
		public IActionResult Greet(string id, [FromServices] ICounterService counter)
		{
			int count = counter.CountNext(id);
			var page = $@"
				<html>
					<head><title>BasicWebApp</title></head>	
					<body>
						<h1>Welcome {id}</h1>
						<b>Number of Greetings: </b>{count}
					</body>
				</html>
			";
			return Content(page, "text/html");
		}
	}
}

