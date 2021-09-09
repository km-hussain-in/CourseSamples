#nullable disable

namespace DemoApp
{
	interface IStack<out V>
	{
		bool Empty();
		V Pop();
	}

	class SimpleStack<V> : IStack<V>
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

		public bool Empty()
		{
			return top == null;
		}

		public V Pop()
		{
			V item = top.Value;
			top = top.Below;
			return item;
		}	

		public System.Collections.Generic.IEnumerator<V> GetEnumerator()
		{
			for(Node n = top; n != null; n = n.Below)
				yield return n.Value;
		}
	}
}

