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

	class ResourceConsumer : IConsumer
	{
		private string id;

		static ResourceConsumer()
		{
			Console.WriteLine("ResourceConsumer type initialized.");
		}

		public ResourceConsumer(string name)
		{
			id = name;
			Console.WriteLine($"{id} resource acquired.");
		}

		public void Apply(int option)
		{
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
		static void Run(string cmd)
		{
			using(IConsumer c = new ResourceConsumer("Third"))
			{
				c.ApplyAll(int.Parse(cmd));
			}
		}

        static void Main(string[] args)
        {
            IConsumer a = new ResourceConsumer("First");
			a.Apply(1);
			a.Dispose();
            IConsumer b = new ResourceConsumer("Second");
			b.Apply(2);
			b.Dispose();
			try
			{
				Run(args[0]);
			}
			catch {}
        }
    }
}

