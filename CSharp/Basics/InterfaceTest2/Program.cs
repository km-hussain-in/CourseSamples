using System;

namespace InterfaceTest2
{
	using Banners;

	class BannerPrinter : IDisposable
	{
		private string? id;

		public BannerPrinter(string name)
		{
			id = name;
			Console.WriteLine($"Acquiring {id} printer resource");
		}

		public double Print(IBanner banner, int copies=1)
		{
			if(copies < 1 || copies > 10)
				throw new ArgumentException("copies");
			for(int i = 1; i <= copies; ++i)
			{
				Console.WriteLine($"Printer {id} - page {i}");
				Console.WriteLine(banner.Style(), banner.Text);
			}
			return banner.Price(copies);
		}

		public void Dispose()
		{
			if(id != null)
			{
				Console.WriteLine($"Releasing {id} printer resource");
				id = null;
			}
		}
	}

    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				float w = float.Parse(args[0]);
				var b1 = new CircularBanner
				{
					Diameter = w,
					Text = "Smooth all around"
				}; 
				var p1 = new BannerPrinter("first");
				Console.WriteLine("Payment: {0:0.00}", p1.Print(b1));
				p1.Dispose();
				float h = float.Parse(args[1]);
				int n = int.Parse(args[2]);
				var b2 = new RectangularBanner()
				{
					Length = w,
					Breadth = h,
					Text = "Sharp at corners"
				};
				using(var p2 = new BannerPrinter("second"))
				{
					Console.WriteLine("Payment: {0:0.00}", p2.Print(b2, n));
				}
			}
			catch {}
        }
    }
}

