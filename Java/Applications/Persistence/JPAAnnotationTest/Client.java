import shopping.ProductEntity;
import javax.persistence.Persistence;

class Client {

	public static void main(String[] args) throws Exception {
		var emf = Persistence.createEntityManagerFactory("ShopPU"); 
		var em = emf.createEntityManager();
		if(args.length == 0){
			var query = em.createQuery("SELECT p FROM ProductEntity p", ProductEntity.class); //using JPQL
			for(var i : query.getResultList())
				System.out.printf("%d\t%.2f\t%d%n", i.getProductNo(), i.getPrice(), i.getStock());
		}else{
			int pno = Integer.parseInt(args[0]);
			var product = em.find(ProductEntity.class, pno);
			for(var i : product.getOrders())
				System.out.printf("%s\t%d\t%s%n", i.getCustomerId(), i.getQuantity(), i.getOrderDate());
		}
		em.close();
	}
}

