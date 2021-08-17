namespace Greeting
{
	using System;
	using System.Dynamic;

	class FormalGreeter
	{
		public string Title { get; set; } = "Mx";

		public DateTime Time => DateTime.Now;

		public string Meet(string visitor) => $"Hello {Title} {visitor}";	
	}

	class CasualGreeter : DynamicObject
	{
		public int Code => Environment.TickCount; 

		public String Greeted { get; set; } = "Nobody";

		public int Count { get; set; } = 0;

		public string Meet(string visitor)
		{
			Greeted = visitor;
			Count += 1;
			return $"Hi {visitor}";
		}

		public override bool TryInvokeMember(InvokeMemberBinder method, object[] arguments, out object result)
		{
			if(method.Name == "Leave" && arguments.Length == 1 && Equals(arguments[0], Greeted))
			{
				result = $"Bye {Greeted}";
				return true;
			}
			result = null;
			return false;
		}

	}
}


