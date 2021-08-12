using System;
using Microsoft.AspNetCore.Mvc;

namespace ClassicWebApp.Controllers
{
	using Models;

	public class HomeController : Controller
	{
		private SiteModel _model;

		public HomeController(SiteModel model) => _model = model;

		public IActionResult Greet(string id)
		{
			ViewBag.Person = id ?? "Visitor";
			return View(DateTime.Now);
		}

		public IActionResult Index()
		{
			return View(_model.ReadVisitors());
		}

		[HttpPost]
		public IActionResult Register(string person)
		{
			if(person.Length > 3)
			{
				_model.WriteVisitor(person);
			}
			return RedirectToAction("Index");
		}
		
	}
}

