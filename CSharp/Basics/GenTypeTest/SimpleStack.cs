namespace GenTypeTest
{
	partial class SimpleStack<V>
	{
		class Node
		{
			internal V Value;
			internal Node Below;
		}

		private Node top;

		public void Push(V item)
		{
			top = new Node {Value=item, Below=top};
		}

		public V Pop()
		{
			V item = top.Value;
			top = top.Below;
			return item;
		}	

		public bool Empty()
		{
			return top == null;
		}
	}
}

