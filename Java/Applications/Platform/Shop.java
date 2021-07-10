import java.io.*;
import java.util.*;

record ItemInfo(double price, int stock) {}

class Shop {

	private Map<String, ItemInfo> store;

	public Shop() throws IOException {
		try(var input = new DataInputStream(new FileInputStream("store.data"))){
			store = new TreeMap<>();
			while(input.available() > 0){
				String name = input.readUTF();
				double price = input.readDouble();
				int stock = input.readInt();
				store.put(name, new ItemInfo(price, stock));
			}
		}
	}

	public ItemInfo find(String item) {
		return store.get(item);
	}
}

