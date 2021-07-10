package shopping;

import java.rmi.RemoteException;
import java.util.Date;
import java.util.List;
import javax.persistence.Persistence;

public class OrderManagerService extends java.rmi.server.UnicastRemoteObject implements OrderManager {
	
	public OrderManagerService() throws RemoteException {
		//super(6002); //exports this object on TCP port 6002
	}

	//implements transactional business logic
	public int placeOrder(String customerId, int productNo, int quantity) throws RemoteException {
		var emf = Persistence.createEntityManagerFactory("ShopPU");
		var em = emf.createEntityManager();
		try{
			var tx = em.getTransaction();
			tx.begin();
			var ctr = em.find(CounterEntity.class, "orders");
			int orderNo = ctr.getNextValue() + 1000;
			var order = new OrderEntity();
			order.setOrderNo(orderNo);
			order.setOrderDate(new Date());
			order.setCustomerId(customerId);
			order.setProductNo(productNo);
			order.setQuantity(quantity);
			em.persist(order);
			tx.commit(); //will rollback if any update fails
			return orderNo;
		}finally{
			em.close();
		}
	}

	//implements data-transfer logic
	public List<OrderEntity> getOrdersOf(String customerId) throws RemoteException {
		var emf = Persistence.createEntityManagerFactory("ShopPU");
		var em = emf.createEntityManager();
		try{
			var query = em.createNamedQuery("findOrdersByCustomerId", OrderEntity.class);
			query.setParameter(1, customerId);
			return query.getResultList();
		}finally{
			em.close();
		}

	}
}

