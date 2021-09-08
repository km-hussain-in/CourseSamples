using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqTest
{
	static class Program
	{
		static void Print(this IEnumerable<object> source)
		{
			foreach(var entry in source)
				Console.WriteLine(entry);
		}

		static void Main(string[] args)
		{
			var shop = new Shop();
			if(args[0] == "items")
			{
				shop.GetItems()
					.Where(i => i.EndsWith(args[1]))
					.Select(i => i.Split('-')[0])
					.Print();
			}
			else if(args[0] == "orders")
			{
				var selection = from e in shop.GetOrders("cpu")
								where e.Quantity >= int.Parse(args[1])
								orderby e.Date
								select new 
								{
									Person = e.Customer.ToUpper(),
									Billed = DateTime.Parse(e.Date),
									Payment = 10000 * e.Quantity
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
				customers.Where(filter).Print();
			}
		}
	}
}
