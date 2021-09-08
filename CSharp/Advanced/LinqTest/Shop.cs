using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqTest
{
	record Order(string Customer, string Date, string item, int Quantity);

	record Contact(string Name, string City, string Zip);

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
				new ("jack", "2020-06-19", item, 3),
				new ("jill", "2021-02-05", item, 8),
				new ("john", "2020-11-09", item, 5),
				new ("jeff", "2020-01-10", item, 2),
				new ("jane", "2021-06-23", item, 6),
				new ("jack", "2020-12-24", item, 10),
				new ("john", "2020-08-09", item, 7)
			};
		}	

		public IQueryable<Contact> GetCustomers()	
		{
			return XElement.Load("customers.xml")
					.Elements("contact")
					.Select(e => new Contact
					(
						Name: (string)e.Attribute("name"),
						City: (string)e.Element("city"),
						Zip: (string)e.Element("zip")
					))
					.AsQueryable();
		}
	}
}

