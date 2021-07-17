using System;

interface IConsumer : IDisposable
{
	void Apply(int action);

	void ApplyAll(int count)
	{
		for(int a = 1; a <= count; ++a)
			Apply(a);
	}
}

class ResourceConsumer : IConsumer
{
	private string id;

	static ResourceConsumer()
	{
		Console.WriteLine("ResourceConsumer type initialized");
	}

	internal ResourceConsumer(string name)
	{
		id = name;
		Console.WriteLine($"{id} resource acquired");
	}

	void IConsumer.Apply(int action)
	{
		if(id != null)
			Console.WriteLine($"{id} resource consumed with action {action}");
	}

	void IDisposable.Dispose()
	{
		if(id != null)
		{
			Console.WriteLine($"{id} resource released");
			id = null;
		}
	}
}	

static class Program
{
	private static void Run(string cmd)
	{
		using(IConsumer c = new ResourceConsumer("third"))
		{
			c.ApplyAll(int.Parse(cmd));
		}
	}

	public static void Main(string[] args)
	{
		IConsumer a = new ResourceConsumer("first");
		a.Apply(1);
		a.Dispose();
		IConsumer b = new ResourceConsumer("second");
		b.Apply(2);
		b.Dispose();
		try
		{
			Run(args[0]);
		}
		catch {}
	}
}

