import java.io.*;
import java.net.*;

class URLClientTest {

	public static void main(String[] args) throws Exception {
		String host = args.length > 1 ? args[1] : "localhost";
		URL url = new URL("http://" + host + ":6004/" + args[0]);
		try{
			var input = url.openStream();
			var reader = new BufferedReader(new InputStreamReader(input));
			System.out.printf("Share Price: %s%n", reader.readLine());
			reader.close();
		}catch(FileNotFoundException e){
			System.out.println("No such symbol!");
		}
	}
}

