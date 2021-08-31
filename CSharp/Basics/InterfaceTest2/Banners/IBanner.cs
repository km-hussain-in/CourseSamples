namespace InterfaceTest2.Banners
{
	public interface IBanner
	{
		string Text { get; }

		double Area();

		double Price(int count)
		{
			float rate = count < 3 ? 0.5f : 0.4f;
			return count * rate * Area() + 0.05 * Text.Length;
		}
		
		string Style()
		{
			return "{0})";
		}

	}
}

