using System;
using System.Threading;
using System.Collections.Generic;

namespace BasicWebApp
{
	public interface ICounterService
	{
		int CountNext(string name);
	}

	public class SimpleCounter : ICounterService
	{
		private readonly Dictionary<string, int> counters = new();

		public int CountNext(string name)
		{
			lock(counters)
			{
				counters.TryGetValue(name, out int count);
				counters[name] = ++count;
				return count;
			}
		}
	}

	public class CyclicCounter : ICounterService
	{
		private readonly int limit;
		private int count = -1;

		public CyclicCounter(int limit) => this.limit = limit;

		public int CountNext(string name)
		{
			return 1 + Interlocked.Increment(ref count) % limit;
		}
	}
}

