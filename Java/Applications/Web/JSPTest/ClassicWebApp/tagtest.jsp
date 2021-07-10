<%@ taglib prefix="x" uri="http://java.met.edu/ClassicWebApp" %>
<html>
	<head>
		<title>ClassicWebApp</title>
	</head>
	<body>
		<h1>Welcome Gambler</h1>
		<b>Current Time: </b><x:clock format="MMM dd, yyyy hh:mm:ss a"/>
		<p>
			<b>Lottery Winner - </b>
			<x:lotto digits="9" id="num">
				<i>${num}</i>
			</x:lotto>
		</p>
	</body>
</html>

