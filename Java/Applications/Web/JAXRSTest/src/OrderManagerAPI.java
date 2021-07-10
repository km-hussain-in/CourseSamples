package modern.web.app;

import shopping.*;
import java.rmi.*;
import java.util.*;
import javax.ws.rs.*;
import javax.ws.rs.core.*;

@Path("/orders")
public class OrderManagerAPI {

	@GET
	@Path("/now")
	@Produces(MediaType.TEXT_PLAIN)
	public String readTime() {
		return new Date().toString();
	}

	@GET
	@Path("/{id}")
	@Produces(MediaType.APPLICATION_JSON)
	public Response readOrders(@PathParam("id") String customer){
		try{
			OrderManager client = (OrderManager)Naming.lookup("rmi://localhost:20000/order-support");
			List<OrderEntity> result = client.getOrdersOf(customer);
			if(result.size() == 0)
				return Response.status(404).build();
			return Response.status(200).entity(result).build();
		}catch(Exception e){
			return Response.status(500).build();
		}
	}

	@POST
	@Consumes(MediaType.APPLICATION_JSON)
	@Produces(MediaType.APPLICATION_JSON)
	public Response createOrder(OrderEntity entry){
		try{
			OrderManager client = (OrderManager)Naming.lookup("rmi://localhost:20000/order-support");
			String customerId = entry.getCustomerId();
			int productNo = entry.getProductNo();
			int quantity = entry.getQuantity();
			int result = client.placeOrder(customerId, productNo, quantity);
			entry.setOrderNo(result);
			return Response.ok(entry).build();
		}catch(Exception e){
			return Response.status(500).build();
		}
	}
}

