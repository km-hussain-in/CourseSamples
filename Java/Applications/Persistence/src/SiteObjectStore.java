package tourism;

import java.io.*;

public class SiteObjectStore {

	public boolean persist(Site site) {
		try(var output = new ObjectOutputStream(new FileOutputStream(site.name + ".store"))){
			output.writeObject(site); //serialization
			return true;
		}catch(Exception e){
			return false;
		}
	}

	public Site fetch(String name) {
		try(var input = new ObjectInputStream(new FileInputStream(name + ".store"))){
			return (Site) input.readObject(); //deserialization
		}catch(Exception e){
			return new Site(name);
		}
	}
}

