<jsp:useBean id="ctr" class="classic.web.app.CounterBean" scope="session"/>
<jsp:useBean id="gtr" class="classic.web.app.GreeterBean" scope="application"/>
<jsp:setProperty name="ctr" property="step" value="3"/>
<jsp:setProperty name="gtr" property="*"/>
<html>
	<head>
		<title>ClassicWebApp</title>
	</head>
	<body>
		<h1>${gtr.greetingMessage}</h1>
		<form method="POST">
			<p>
				<b>Person: </b>
				<input type="text" name="person"/>
			</p>
			<p>
				<b>Period: </b>
				<select name="period">
					<option>Night</option>
					<option>Morning</option>
					<option>Afternoon</option>
					<option>Evening</option>
				</select>
			</p>
			<input type="submit" value="Greet"/>
		</form>
		<p>
			<b>Visitation Count: </b>${ctr.nextValue}
		</p>
	</body>
</html>

