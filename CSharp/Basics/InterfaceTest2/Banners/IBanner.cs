namespace InterfaceTest2.Banners
{
	public interface IBanner
	{
		string Text { get; }

		double Area();

		double Price()
		{
			return 0.75 * Area() + 0.05 * Text.Length;
		}
		
		string Style()
		{
			return "({0})";
		}

	}
}

