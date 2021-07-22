using System;
using System.Collections;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace LinqTest
{
	partial class SimpleStack<V> : IEnumerable<V>
	{

		public IEnumerator<V> GetEnumerator()
		{
			for(Node n = top; n != null; n = n.Below)
				yield return n.Value;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	}

	record Investment(int Period, double Amount);

	class Program
	{
		static void Main(string[] args)
		{
			int limit = args.Length > 0 ? int.Parse(args[0]) : 0;
			var store = new SimpleStack<Investment>();
			store.Push(new Investment(3, 71000));
			store.Push(new(5, 82000));
			store.Push(new(4, 63000));
			store.Push(new(2, 34000));
			store.Push(new(6, 45000));
			store.Push(new(1, 56000));
			/*
			foreach(var i in store)
			{
				if(i.Period > limit)
				{
					double cash = i.Amount * Math.Pow(1.08, i.Period);
					Console.WriteLine("{0}\t{1}\t{2:0.00}", i.Amount, 12 * i.Period, cash);
				}
			}
			*/
			/*
			var selection = store.Where(i => i.Period > limit)
							.Select(i => new 
							{
								Invest = i.Amount,
								Months = 12 * i.Period,
								Cash = i.Amount * Math.Pow(1.07, i.Period)
							});
			*/
			var selection = from i in store
							where i.Period > limit
							select new
							{
								Invest = i.Amount,
								Months = 12 * i.Period,
								Cash = i.Amount * Math.Pow(1.07, i.Period)
							};
			foreach(var i in selection)
					Console.WriteLine("{0}\t{1}\t{2:0.00}", i.Invest, i.Months, i.Cash);

		}
	}
}
