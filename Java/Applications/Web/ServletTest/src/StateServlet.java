package basic.web.app;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

@javax.servlet.annotation.WebServlet("/state")
public class StateServlet extends HttpServlet {

	@Override
	public void doPost(HttpServletRequest request, HttpServletResponse response) throws IOException, ServletException {
		String name = request.getParameter("id");
		if(name.length() == 0) {
			response.sendRedirect("welcome.gws");
			return;
		}
		HttpSession session = request.getSession(true);
		Integer count = (Integer)session.getAttribute(name);
		if(count == null) count = 1;
		session.setAttribute(name, count + 1);
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println("<html>");
		out.println("<head><title>BasicWebApp</title></head>");
		out.println("<body>");
		out.printf("<h1>Hello %s</h1>%n", name);
		out.printf("<b>Number of greetings = </b>%d%n", count);
		out.println("</body>");
		out.println("</html>");
		if(count > 4)
			session.invalidate();
	}
}

