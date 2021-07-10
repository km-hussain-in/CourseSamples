import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.DataInputStream;
import java.io.DataOutputStream;

class FileStreamTest2 {

	public static void main(String[] args) throws Exception {
		if(args.length > 2){
			String name = args[0].toLowerCase();
			double price = Double.parseDouble(args[1]);
			int stock = Integer.parseInt(args[2]);
			var output = new DataOutputStream(new FileOutputStream("store.data", true));
			output.writeUTF(name);
			output.writeDouble(price);
			output.writeInt(stock);
			output.close();
		}else{
			double total = 0;
			var input = new DataInputStream(new FileInputStream("store.data"));
			while(input.available() > 0){
				String name = input.readUTF();
				double price = input.readDouble();
				int stock = input.readInt();
				total += stock * price;
				System.out.printf("%-16s%10.2f%8d%n", name, price, stock);
			}
			input.close();
			System.out.printf("Total investment: %.2f%n", total);
		}
	}
}

