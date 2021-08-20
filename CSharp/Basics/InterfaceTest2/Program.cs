using System;

namespace InterfaceTest2
{
	interface IConsumer : IDisposable
	{
		void Apply(int option);

		void ApplyAll(int count)
		{
			for(int opt = 1; opt <= count; ++opt)
				Apply(opt);
		}
	}

	static class Consumer
	{
		public static void Consume(this IConsumer that, int option)
		{
			try
			{
				that.Apply(option);
			}
			finally
			{
				that.Dispose();
			}
		}
	}

	class ResourceConsumer : IConsumer
	{
		private string? id;

		public ResourceConsumer(string name)
		{
			id = name;
			Console.WriteLine($"{id} resource acquired.");
		}

		public void Apply(int option)
		{
			if(option <= 0)
				throw new ArgumentException("option");
			if(id != null)
				Console.WriteLine($"{id} resource consumed with action<{option}>.");
		}

		public void Dispose()
		{
			if(id != null)
			{
				Console.WriteLine($"{id} resource released.");
				id = null;
			}
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
			try
			{
            	IConsumer a = new ResourceConsumer("First");
				a.Apply(1);
				a.Dispose();
				int m = int.Parse(args[0]);
            	IConsumer b = new ResourceConsumer("Second");
				b.Consume(m);
				int n = int.Parse(args[1]);
				using(IConsumer c = new ResourceConsumer("Third")){
					c.ApplyAll(n);
				}
			}
			catch {}
        }
    }
}

