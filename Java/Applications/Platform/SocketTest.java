import java.io.*;
import java.net.*;

//Implementing a TCP/IP client program
/*
Step 1: Open a stream socket with host and port address of the server
Step 2: Get the streams of the above socket and use to to exchange data with the server
Step 3: Close the above streams and socket.
*/

class SocketTest {
	
	public static void main(String[] args) throws Exception {
		String host = args.length > 1 ? args[1] : "localhost"; //localhost => 127.0.0.1
		var server = new Socket(host, 6001);
		var reader = new BufferedReader(new InputStreamReader(server.getInputStream()));
		var writer = new PrintWriter(new OutputStreamWriter(server.getOutputStream()));
		System.out.println(reader.readLine());
		writer.println(args[0]);
		writer.flush();
		String info = reader.readLine();
		if(info != null){
			String[] parts = info.split("&");
			System.out.println(parts[0]);
			System.out.println(parts[1]);
		}else{
			System.out.println("Item not sold!");
		}
		writer.close();
		reader.close();
		server.close();
	}
}

