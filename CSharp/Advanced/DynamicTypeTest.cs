using System;
using System.Dynamic;

class FormalGreeter
{
	public string Greet(string visitor)
	{
		return $"Hello {visitor}";
	}
}

class CasualGreeter : DynamicObject
{
	public string Greet(string visitor)
	{
		return $"Hi {visitor}";
	}

	public override bool TryInvokeMember(InvokeMemberBinder method, object[] parameters, out object result)
	{
		if(parameters.Length == 1)
		{
			result = $"Cannot {method.Name} {parameters[0]}";
			return true;
		}

		result = null;
		return false;
	} 
}

static class Program
{
	public static void Main(string[] args)
	{
		try
		{	
			Type t = Type.GetType(args[0], true);
			dynamic g = Activator.CreateInstance(t); //DLR call-site will be created for g to support duck typing
			Console.WriteLine(g.Greet("Jack"));
			Console.WriteLine(g.Kill("Jack"));
		}
		catch(Exception ex)
		{
			Console.WriteLine("Error: {0}", ex.Message);
		}
	}
}
