namespace ObjectClassTest
{
	struct Rectangle
	{
		public int Length, Breadth;

		public Rectangle(int length, int breadth)
		{
			Length = length;
			Breadth = breadth;
		}

		public override string ToString()
		{
			return $"{Length}X{Breadth}";
		}
	}
}

