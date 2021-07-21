.assembly Hello {}
.assembly extern System.Console {}

.method public static void Start()
{
	.entrypoint

	ldstr	"Hello World!"
	call	void [System.Console]System.Console::WriteLine(string)
	ret
}

