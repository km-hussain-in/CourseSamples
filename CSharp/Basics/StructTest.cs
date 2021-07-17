using System;

struct HotelRoom
{
	public int Number;
	public bool Taken;

	public void Print()
	{
		string state = Taken ? "occupied" : "available";
		Console.WriteLine($"Room {Number} is currently {state}");
	}
}

static class Program
{
	private static void Reserve(ref HotelRoom room)
	{
		if(room.Taken)
			throw new ArgumentException("Reservation failed");
		room.Taken = true;
	}

	public static void Main()
	{
		HotelRoom myroom;
		myroom.Number = 503;
		myroom.Taken = false;
		myroom.Print();
		Console.WriteLine("Reserving this room...");
		Reserve(ref myroom);
		myroom.Print();
	}
}

