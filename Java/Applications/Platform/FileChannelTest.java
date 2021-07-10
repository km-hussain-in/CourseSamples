import java.nio.channels.FileChannel;
import java.nio.file.Path;
import java.nio.file.StandardOpenOption;

//reverses content of a specified file using memory-mapped i/o
class FileChannelTest {

	public static void main(String[] args) throws Exception {
		var doc = Path.of(args[0]);
		try(var channel = FileChannel.open(doc, StandardOpenOption.READ, StandardOpenOption.WRITE)){
			var lock = channel.lock(); //other processes will not be allowed to access this file image
			int n = (int)channel.size();
			var image = channel.map(FileChannel.MapMode.READ_WRITE, 0, n);
			for(int i = 0, j = n - 1; i < j; ++i, j--){
				byte ib = image.get(i);
				byte jb = image.get(j);
				image.put(i, jb);
				image.put(j, ib);
			}
			lock.release();
		}
	}
}

