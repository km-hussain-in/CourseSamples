using System;

namespace StructTest
{
	struct HotelRoom
	{
		public int Number;
		public int Beds;
		public bool Taken;

		public double GetRate()
		{
			return 850 + 100 * Beds;
		}

	}

    class Program
    {
		static void PrintRoom(in HotelRoom room)
		{
			string status = room.Taken ? "occupied" : "available";
			Console.WriteLine($"Room {room.Number} is currently {status}.");
		}

		static void ReserveRoom(ref HotelRoom room, int days)
		{
			if(room.Taken)
				Console.WriteLine("Reservation failed!");
			else
			{
				room.Taken = true;
				Console.WriteLine("Total Payment: {0:0.00}", days * room.GetRate());
			}
		}

        static void Main(string[] args)
        {
			HotelRoom myroom;
			myroom.Number = 504;
			myroom.Beds = 2;
			myroom.Taken = false;
			PrintRoom(myroom);
			Console.WriteLine("Reserving this room...");
			ReserveRoom(ref myroom, 1);
			PrintRoom(myroom);
        }
    }
}
