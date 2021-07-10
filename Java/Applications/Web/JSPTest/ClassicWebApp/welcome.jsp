<jsp:useBean id="now" class="java.util.Date" />
<html>
	<head>
		<title>ClassicWebApp</title>
	</head>
	<body>
		<h1>Welcome ${empty param.id ? "Visitor" : param.id}</h1>
		<b>Current Time: </b>${now}
	</body>
</html>

