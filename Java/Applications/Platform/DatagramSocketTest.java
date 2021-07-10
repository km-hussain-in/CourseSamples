import java.net.*;
import java.util.*;

class DatagramSocketTest {

	public static void main(String[] args) throws Exception {
		String[] symbols = {"APPL", "GOGL", "INTC", "MSFT", "ORCL"};
		var rdm = new Random();
		var publisher = new DatagramSocket();
		var classDAddr = InetAddress.getByName("230.0.0.1"); //Class D Address: 224-239.0-255.0-255.0-255
		for(;;) {
			int i = rdm.nextInt(symbols.length);
			double p = 0.01 * (1000 + rdm.nextInt(9000));
			String msg = String.format("%s - %.2f", symbols[i], p);
			var packet = new DatagramPacket(msg.getBytes(), msg.length(), classDAddr, 6002);
			publisher.send(packet);
			Thread.sleep(5000);
		}
	}

}


