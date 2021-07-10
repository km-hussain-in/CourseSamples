	.set sysarch, _x64_
	.include "console.i"

	.text
	
	.entry	main
main:
	GetInt	ask, num

	mov	rax, 1
	mov	rbx, num
	mov	rcx, 0

1:	inc	rcx		#rcx=rcx+1	
	mov	rdx, 10
	mul	rdx		#rax=rax*10

	cmp	rax, rbx
	jle	1b

	mov	rax, rcx
	PutInt	ans

	ret

ask:	.string "Positive Integer: "
ans:	.string "Number of Digits = "

	.data

num:	.quad	0
	

	.end

