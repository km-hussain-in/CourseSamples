using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;

namespace DemoApp
{
	public class Order
	{
		public int Id { get; set; }

		public DateTime OrderDate { get; set; }

		public string CustomerId { get; set; }

		public int ProductNo { get; set; }

		public int Quantity { get; set; }
	}

	public class OrdersClientModel
	{
		const string serviceBase = "http://localhost:5000/api";

		readonly HttpClient client = new();

		public Task<List<Order>> GetCustomerOrdersAsync(string customerId)
		{
			return client.GetFromJsonAsync<List<Order>>($"{serviceBase}/orders/{customerId}");
		}

		public async Task<int> PostOrderAsync(Order entry)
		{
			var response = await client.PostAsJsonAsync($"{serviceBase}/orders", entry);
			response.EnsureSuccessStatusCode();
			var order = await response.Content.ReadFromJsonAsync<Order>();
			return order.Id;
		}
	}
}

