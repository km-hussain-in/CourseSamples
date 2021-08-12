using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

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

	public class CyclicCounterOptions
	{
		public int Limit { get; set; }
	}

	public class CyclicCounter : ICounterService
	{
		private readonly int limit;
		private int count = -1;

		public CyclicCounter(IOptions<CyclicCounterOptions> options) => limit = options.Value.Limit;

		public int CountNext(string name)
		{
			return 1 + Interlocked.Increment(ref count) % limit;
		}
	}
}

