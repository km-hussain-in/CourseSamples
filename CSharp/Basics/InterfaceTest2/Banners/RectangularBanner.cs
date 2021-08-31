namespace InterfaceTest2.Banners
{
	public struct RectangularBanner : IBanner
	{
		public float Length { get; set; }	
		
		public float Breadth { get; set; }	

		public string Text { get; set; }

		public string Style()
		{
			return "[{0}]";
		}

		public double Area()
		{
			return Length * Breadth;
		}
	}
}

