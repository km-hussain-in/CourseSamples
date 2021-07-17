using System;
using System.IO;
using System.Net.Sockets;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
			string symbol = args[0].ToUpper();
			string host = args.Length > 1 ? args[1] : "localhost";
			using var client = new TcpClient(host, 6001);
			using var reader = new StreamReader(client.GetStream());
			using var writer = new StreamWriter(client.GetStream());
			writer.WriteLine(symbol);
			writer.Flush();
			string response = reader.ReadLine();
			if(response != null)
				Console.WriteLine("Price is {0}", response);
			else
				Console.WriteLine("Price not available");
        }
    }
}




