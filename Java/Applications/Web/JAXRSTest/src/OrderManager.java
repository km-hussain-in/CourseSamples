package shopping;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.List;

public interface OrderManager extends Remote {

	int placeOrder(String customerId, int productNo, int quantity) throws RemoteException;

	List<OrderEntity> getOrdersOf(String customerId) throws RemoteException;
}

