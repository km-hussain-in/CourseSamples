using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqTest
{
	record Order(string Customer, string Date, int Quantity);

	record Dealer(string Name, string City, string Item);

	class Shop
	{
		public IEnumerable<string> GetItems()
		{
			return new string[] {"cpu-intel", "hdd-samsung", "mouse-microsoft", "ddr-samsung", "hdd-seagate", "motherboard-intel", "monitor-samsung"};
		}

		public IEnumerable<Order> GetOrders(string item)
		{
			return new List<Order>
			{
				new ("jack", "2020-06-19", 3),
				new ("jill", "2021-02-05", 8),
				new ("john", "2020-11-09", 5),
				new ("jeff", "2020-01-10", 2),
				new ("jane", "2021-06-23", 6),
				new ("jack", "2020-12-24", 10),
				new ("john", "2020-08-09", 7)
			};
		}	

		public IQueryable<Dealer> GetSuppliers()	
		{
			return XElement.Load("suppliers.xml")
					.Elements("dealer")
					.Select(e => new Dealer
					(
						Name: (string)e.Element("name"),
						City: (string)e.Element("city"),
						Item: (string)e.Attribute("item")
					))
					.AsQueryable();
		}
	}
}

