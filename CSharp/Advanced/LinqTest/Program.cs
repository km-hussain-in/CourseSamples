using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var shop = new Shop();
			if(args[0] == "outlets")
			{
				var outlets = shop.GetOutlets()
								.Where(e => e.Item1 == args[1])
								.Select(e => e.Item2);
				foreach(string city in outlets)
					Console.WriteLine(city);
			}
			else if(args[0] == "orders")
			{
				var orders = shop.GetOrders();
				var selection = from e in orders
								where e.Quantity >= int.Parse(args[1])
								orderby e.Date
								select new 
								{
									Person = e.Customer.ToUpper(),
									Billed = DateTime.Parse(e.Date),
									Payment = 1000 * e.Quantity
								};
				foreach(var entry in selection)
					Console.WriteLine($"{entry.Person}\t{entry.Payment}\t{entry.Billed:MMM dd, yyyy}");
			}
			else if(args[0] == "customers")
			{
				var customers = shop.GetCustomers();
				var prm = Expression.Parameter(typeof(Contact));
				var eql = Expression.Equal
				(
					Expression.Property(prm, args[1]),
					Expression.Constant(args[2])
				);
				var filter = Expression.Lambda<Func<Contact, bool>>(eql, prm);
				var selection = customers.Where(filter);
				foreach(var entry in selection)
					Console.WriteLine(entry);
			}
		}
	}
}
