package basic.web.app;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

@javax.servlet.annotation.WebServlet("*.htmx")
public class HtmxServlet extends HttpServlet {

	@Override
	public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
		String path = request.getServletPath();
		String file = super.getServletContext().getRealPath(path);
		if(file == null){
			response.sendError(404);
			return;
		}
		String time = new java.util.Date().toString();
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		try(BufferedReader reader = new BufferedReader(new FileReader(file))){
			reader.lines()
				.map(l -> l.replaceAll("<x:now/>", time))
				.forEach(out::println);
				
		}
	}
}

