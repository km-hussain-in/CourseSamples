	.set sysarch, _x64_
	.include "console.i"

	.text
	
	.entry	main
main:	
	#Input an integer value (N) into variable upper
	GetInt	asku, upper

	#reg1 = upper = N
	mov	rax, upper

	#reg2 = reg1 + 1 = N+1
	mov	rdx, rax
	add	rdx, 1

	#reg1 = reg1 * reg2 = N*(N+1)
	mul	rdx

	#reg1 = reg1 / 2 = N*(N+1)/2
	shr	rax, 1

	#Output integer value in reg1
	PutInt	ans

	ret

asku:	.string "Upper Limit: "
ans:	.string "Sum of Integers = "

	.data

upper:	.quad	0
	#allocate a memory block for a 64-bit (8 byte quad word) integer value and link its
	#logical address to label upper
	

	.end

