package classic.web.app;

import java.util.*;
import java.sql.*;
import javax.sql.*;
import javax.naming.*;

public class ModelBean implements java.io.Serializable {

	public List<ProductEntry> getProducts() throws Exception {
		List<ProductEntry> products = new ArrayList<>();
		Context naming = new InitialContext();
		DataSource pool = (DataSource)naming.lookup("jdbc/SalesDB");
		try(Connection con = pool.getConnection()){
			Statement stmt = con.createStatement();
			ResultSet rs = stmt.executeQuery("select pno, price, stock from products");
			while(rs.next())
				products.add(new ProductEntry(rs));
			rs.close();
			stmt.close();
		}
		return products;
	}

	public static class ProductEntry {

		private int productNo;
		private double price;
		private int stock;

		ProductEntry(ResultSet row) throws SQLException {
			productNo = row.getInt("pno");
			price = row.getDouble("price");
			stock = row.getInt("stock");
		}

		public final int getProductNo() { return productNo; }

		public final double getPrice() { return price; }

		public final int getStock() { return stock; }
	}
}


