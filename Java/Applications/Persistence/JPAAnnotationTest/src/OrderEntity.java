package shopping;

import java.util.Date;
import javax.persistence.*;

@Entity
@Table(name="orders")
public class OrderEntity implements java.io.Serializable {

	@Id
	@Column(name="ord_no")
	private int orderNo;

	@Column(name="ord_date")
	private Date orderDate;

	@Column(name="cust_id")
	private String customerId;

	@Column(name="pno")
	private int productNo;

	@Column(name="qty")
	private int quantity;

	public int getOrderNo() { return orderNo; }
	public void setOrderNo(int value) { orderNo = value; }

	public Date getOrderDate() { return orderDate; }
	public void setOrderDate(Date value) { orderDate = value; }

	public String getCustomerId() { return customerId; }
	public void setCustomerId(String value) { customerId = value; }

	public int getProductNo() { return productNo; }
	public void setProductNo(int value) { productNo = value; }

	public int getQuantity() { return quantity; }
	public void setQuantity(int value) { quantity = value; }
}

