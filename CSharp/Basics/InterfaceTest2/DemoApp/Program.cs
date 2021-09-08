using System;

namespace DemoApp
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
				Console.WriteLine($"Printing {id} page {i}");
				Console.WriteLine("--------------------------------");
				Console.WriteLine(banner.Style(), banner.Text);
				Console.WriteLine("--------------------------------");
			}
			return copies * banner.Price();
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
		static void Run(float w)
		{
			var b = new CircularBanner
			{
				Diameter = w,
				Text = "Smooth all around"
			}; 
			var p = new BannerPrinter("shared");
			Console.WriteLine("Payment: {0:0.00}", p.Print(b));
			p.Dispose();
		}

		static void Run(float w, float h, int n)
		{
			var b = new RectangularBanner()
			{
				Length = w,
				Breadth = h,
				Text = "Sharp at corners"
			};
			using(var p = new BannerPrinter("shared"))
			{
				Console.WriteLine("Payment: {0:0.00}", p.Print(b, n));
			}

		}

        static void Main(string[] args)
        {
			try
			{
				if(args.Length < 3)
					Run(float.Parse(args[0]));
				else
					Run(float.Parse(args[0]), float.Parse(args[1]), int.Parse(args[2]));
			}
			catch{}
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey(false);
        }
    }
}

