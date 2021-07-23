using System;
using System.Text;
using System.IO.Pipes;

namespace GenHostTest
{
	class ClientSupport
	{
		public static void Run(string text)
		{
			using var client = new NamedPipeClientStream(".", "ghtpipe", PipeDirection.InOut);
			byte[] request = Encoding.UTF8.GetBytes(text);
			try
			{
				client.Connect(5000);
				client.Write(request, 0, request.Length);
				byte[] response = new byte[80];
				int n = client.Read(response, 0, response.Length);
				Console.WriteLine("Response: {0}", Encoding.UTF8.GetString(response, 0, n));
			}
			catch(TimeoutException)
			{
				Console.WriteLine("Service not available, try later.");
			}
        }
    }
}
