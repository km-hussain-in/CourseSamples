#nullable disable

namespace GenTypeTest
{
	interface IStackReader<out V>
	{
		bool Empty();
		V Pop();
	}

	class SimpleStack<V> : IStackReader<V>
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

		public System.Collections.Generic.IEnumerator<V> GetEnumerator()
		{
			for(Node n = top; n != null; n = n.Below)
				yield return n.Value;
		}
	}
}

