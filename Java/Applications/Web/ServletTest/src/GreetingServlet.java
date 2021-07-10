package basic.web.app;

import java.io.*;
import javax.servlet.*;

public class GreetingServlet implements Servlet {

	private ServletConfig config;

	public void init(ServletConfig cfg) throws ServletException { config = cfg; }

	public ServletConfig getServletConfig() { return config; };

	public String getServletInfo() { return "Basic Greeting Servlet"; }

	public void service(ServletRequest request, ServletResponse response) throws IOException, ServletException {
		String name = request.getParameter("id");
		if(name == null)
			name = "Visitor";
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println("<html>");
		out.println("<head><title></title></head>");
		out.println("<body>");
		out.printf("<h1>Welcome %s</h1>%n", name);
		out.printf("<b>Current Time: </b>%s%n", new java.util.Date());
		out.println("</body>");
		out.println("</html>");
		out.close();
	}

	public void destroy() {}


}

