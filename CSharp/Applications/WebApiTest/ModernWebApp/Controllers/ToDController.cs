using System;
using Microsoft.AspNetCore.Mvc;

namespace ModernWebApp
{
	[ApiController, Route("rest/time")]
	public class ToDController : ControllerBase
	{
		[HttpGet("now")]
		public string GetTime()
		{
			return DateTime.Now.ToString();
		}
	}
}

