using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BasicWebApp.TagHelpers
{
	[HtmlTargetElement("span", Attributes="time-display-format")]
	public class ClockTagHelper : TagHelper
	{
		public string TimeDisplayFormat { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.Attributes.RemoveAll("time-display-format");
			output.Content.SetContent(DateTime.Now.ToString(TimeDisplayFormat));
		}
	}
}

