using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ModernWebApp
{
	using Models;

	[ApiController, Route("api/[controller]")]
	public class OrdersController : ControllerBase
	{
		private ShopModel _model;

		public OrdersController(ShopModel model) => _model = model;
		
		[HttpGet("{id}")]
		public ActionResult<List<Order>> ReadCustomerOrders(string id)
		{	
			var result = _model.GetCustomerOrders(id);
			if(result == null)
				return NotFound();
			return result;
		}

		[HttpPost]
		public ActionResult<Order> CreateOrder([FromBody] Order entry)
		{	
			
			if(_model.ProcessOrder(entry))
				return entry;
			return StatusCode(500);

		}
	}
}

