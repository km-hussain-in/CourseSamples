using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace LinqTest
{
	record Order(string Customer, String Date, int Quantity);

	record Contact(string Name, string City, string Zip);

	class Shop
	{
		public IEnumerable<(string, string)> GetOutlets()
		{
			return new (string, string)[]{("MH", "Mumbai"), ("GJ", "Surat"), ("MH", "Pune"), ("MP", "Bhopal"), ("MH", "Nashik"), ("WB", "Kolkata"), ("TG", "Hyderabad")};
		}

		public IEnumerable<Order> GetOrders()
		{
			return new SimpleStack<Order>
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

