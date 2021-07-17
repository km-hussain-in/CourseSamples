using System;

namespace HttpClientApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
			string customerId = args[0].ToUpper();
			var model = new OrdersClientModel();
			if(args.Length < 3)
			{
				var orders = await model.GetCustomerOrdersAsync(customerId);
				foreach(var item in orders)
            		Console.WriteLine($"{item.ProductNo}\t{item.Quantity}\t{item.OrderDate}");
			}
			else
			{
				var order = new Order {CustomerId = customerId};
				order.ProductNo = int.Parse(args[1]);
				order.Quantity = int.Parse(args[2]);
				int orderNo = await model.PostOrderAsync(order);
				Console.WriteLine($"New Order Number: {orderNo}");
			}
        }
    }
}

