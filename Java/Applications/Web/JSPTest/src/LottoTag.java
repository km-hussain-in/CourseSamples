package classic.web.app;

import java.io.*;
import java.util.*;
import javax.servlet.jsp.*;
import javax.servlet.jsp.tagext.*;

public class LottoTag extends SimpleTagSupport {

	private static Random rdm = new Random();
	private int digits = 8;
	private String id;

	public void setDigits(int value) { digits = value; }

	public void setId(String name) { id = name; }

	@Override
	public void doTag() throws JspException, IOException {
		JspContext context = super.getJspContext();
		JspFragment body = super.getJspBody();
		for(int i = 0; i < digits; ++i){
			int dig = rdm.nextInt(10);
			context.setAttribute(id, dig); //assigning dig to an attribute whose name is given by id within the page-context
			body.invoke(null); //output body-content in current response
		}
	}
}

