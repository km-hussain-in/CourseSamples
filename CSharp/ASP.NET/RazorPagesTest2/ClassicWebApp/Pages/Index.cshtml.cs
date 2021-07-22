using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;	
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClassicWebApp.Pages
{
	using Data;

	public class IndexModel : PageModel
	{

		public IEnumerable<Visitor> OurVisitors;

		public void OnGet()
		{
			using var db = new SiteDbContext();
			OurVisitors = db.Visitors.ToList();
		}

		[BindProperty]
		public string Person { get; set; }

		public IActionResult OnPost()
		{
			using var db = new SiteDbContext();
			if(Person.Length > 3)
			{
				var visitor = db.Visitors.Find(Person);
				if(visitor == null)
				{
					visitor = new Visitor {Id = Person};
					db.Visitors.Add(visitor);
				}
				visitor.Frequency += 1;
				visitor.Recent = DateTime.Now;
				db.SaveChanges();
			}	
			return RedirectToPage();
		}
	}
}

