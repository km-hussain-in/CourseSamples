namespace InterfaceTest2.Banners
{
	public struct CircularBanner : IBanner
	{
		public float Diameter { get; set; }	

		public string Text { get; set; }

		public string Style()
		{
			return "({0})";
		}

		public double Area()
		{
			return 3.14 * Diameter * Diameter / 4;
		}
	}
}

