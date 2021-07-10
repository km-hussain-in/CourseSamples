package classic.web.app;

import java.io.*;
import java.util.*;
import java.text.*;
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;

public class ClockTag implements SimpleTag {

	private JspContext context;
	private JspFragment body;
	private JspTag parent;

	public void setJspContext(JspContext value) { context = value; }

	public void setJspBody(JspFragment value) { body = value; }

	public void setParent(JspTag value) { parent = value; }

	public JspTag getParent() { return parent; }

	public void doTag() throws JspException, IOException {
		JspWriter page = context.getOut();
		Date now = new Date();
		page.print(formatter.format(now));
	}

	private SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

	public void setFormat(String value) {
		formatter.applyPattern(value);
	}
}

