import java.io.FileInputStream;
import java.io.FileOutputStream;

class FileStreamTest1 {
	
	public static void main(String[] args) throws Exception {
		var input = new FileInputStream(args[0]);
		var output = new FileOutputStream(args[1]);
		byte[] buffer = new byte[80];
		while(input.available() > 0){
			int n = input.read(buffer, 0, buffer.length);
			for(int i = 0; i < n; ++i)
				buffer[i] = (byte)(buffer[i] ^ '#');
			output.write(buffer, 0, n);
		}
		output.close();
		input.close();
	}
}

