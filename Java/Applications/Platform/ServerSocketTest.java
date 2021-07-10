import java.io.*;
import java.net.*;

//Implementing a TCP/IP server program
/*
 Step 1 - create a listener socket and bind it to a wellknown local endpoint (host and port address)
 Step 2 - accept a stream socket corresponding to the client's connection request received by the above listener socket
 Step 3 - get the input and output streams of above client socket and use them to exchange data with that client
 Step 4 - close above streams and client socket and go to step 2
*/

class ServerSocketTest {

	public static void main(String[] args) throws Exception {
		var listener = new ServerSocket();
		var local = new InetSocketAddress("0.0.0.0", 6001);
		listener.bind(local);
		//service(listener);
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
		var shop = new Shop();
		for(;;){
			var client = server.accept();
			client.setSoTimeout(30000);
			var reader = new BufferedReader(new InputStreamReader(client.getInputStream()));
			var writer = new PrintWriter(new OutputStreamWriter(client.getOutputStream()));
			try{
				writer.println("Welcome to Silver-Palace shop");
				writer.flush();
				String item = reader.readLine();
				var info = shop.find(item);
				if(info != null){
					writer.printf("Price=%.2f&Stock=%d%n", info.price(), info.stock());
					writer.flush();
				}
			}catch(Exception e){}
			writer.close();
			reader.close();
			client.close();
		}
	}
}



