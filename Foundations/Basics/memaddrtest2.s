	.set sysarch, _x64_
	.include "console.i"

	.text
	
	.entry	main
main:	
	GetInt	ask, month

	mov	rcx, month		#direct addressing
	sub	rcx, 1
	mov	rbx, offset year
	mov	rax, [rbx+8*rcx]	#indirect addressing

	PutInt	ans

	ret

ask:	.string	"Month[1-12]: "
ans:	.string	"Number of Days = "

year:	.quad	31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31

	.data

month:	.quad	0

	.end

