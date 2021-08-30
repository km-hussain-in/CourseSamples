using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BasicWebApp
{
	public static class HtmlHelpers
	{
		public static IHtmlContent CurrentTimeAs(this IHtmlHelper that, string pattern=null)
		{
			return new HtmlString(DateTime.Now.ToString(pattern));
		}
	}
}


