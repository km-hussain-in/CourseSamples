using System;
using System.Linq;
using System.Collections.Generic;

namespace ModernWebApp.Models
{

	public class ShopModel
	{
		private ShopDbContext _db;

		public ShopModel(ShopDbContext db) => _db = db;

		public bool ProcessOrder(Order entry)
		{
			try
			{
				var ctr = _db.Counters.Find("order");
				entry.Id = ++ctr.CurrentValue + ctr.SeedValue;
				entry.OrderDate = DateTime.Now;
				_db.Orders.Add(entry);
				_db.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}

		}

		public List<Order> GetCustomerOrders(string customerId)
		{
			var customer = _db.Customers.Find(customerId);
			if(customer != null)
			{
				_db.Entry(customer).Collection(e => e.Orders).Load();
				return customer.Orders.ToList();
			}
			return null;
		}

	}

}

