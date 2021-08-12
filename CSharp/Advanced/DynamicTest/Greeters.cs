namespace DynamicTest
{
	class CasualGreeter
	{
		public string Meet(string visitor) => $"Hi {visitor}";

		public string Leave(string visitor) => $"Bye {visitor}";

	}
	
	class FormalGreeter
	{
		public string Meet(string visitor) => $"Hello {visitor}";	
	}
}
