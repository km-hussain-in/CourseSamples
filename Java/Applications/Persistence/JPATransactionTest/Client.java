import shopping.OrderManager;
import java.rmi.Naming;

class Client {

	public static void main(String[] args) throws Exception {
		var stub = (OrderManager) Naming.lookup("rmi://localhost:20000/order-support");
		String customerId = args[0].toUpperCase();
		if(args.length > 2){
			int productNo = Integer.parseInt(args[1]);
			int quantity = Integer.parseInt(args[2]);
			try{
				int orderNo = stub.placeOrder(customerId, productNo, quantity);
				System.out.printf("New Order Number: %d%n", orderNo);
			}catch(Exception e){
				System.out.printf("Order Failed: %s%n", e.getCause().getMessage());
			}
		}else{
			for(var i : stub.getOrdersOf(customerId))
				System.out.printf("%d\t%d\t%s%n", i.getProductNo(), i.getQuantity(), i.getOrderDate());
		}
	}
}

