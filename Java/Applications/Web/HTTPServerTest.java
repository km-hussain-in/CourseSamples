import java.io.*;
import java.net.*;
import java.util.*;

class HTTPServerTest {

	public static void main(String[] args) throws Exception {
		var listener = new ServerSocket();
		var local = new InetSocketAddress("0.0.0.0", 6004);
		listener.bind(local);
		for(int i = 0; i < 3; ++i){
			Thread child = new Thread(() -> {
				try{
					service(listener);
				}catch(IOException e){}
			});
			child.start();
		}
	}

	private static void service(ServerSocket server) throws IOException {
		String[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		//Arrays.sort(symbols);
		var rdm = new Random();
		for(;;){
			var client = server.accept();
			client.setSoTimeout(30000);
			var reader = new BufferedReader(new InputStreamReader(client.getInputStream()));
			var writer = new PrintWriter(new OutputStreamWriter(client.getOutputStream()));
			try{
				String request = reader.readLine();
				while(reader.readLine().length() > 0);
				String symbol = request.split(" ")[1].substring(1).toUpperCase();
				int i = Arrays.binarySearch(symbols, symbol);
				if(i >= 0){
					double price = 0.01 * (1000 + rdm.nextInt(9000));
					writer.printf("HTTP/1.1 200 OK\r\n");
					writer.printf("Content-Type: text/plain\r\n\r\n");
					writer.printf("%.2f\r\n", price);
				}else{
					writer.printf("HTTP/1.1 404 Not Found\r\n\r\n");
				}
			}catch(Exception e){}
			writer.close();
			reader.close();
			client.close();
		}
	}
}


//http://server:6004/msft
//GET /msft HTTP/1.0\r\n
