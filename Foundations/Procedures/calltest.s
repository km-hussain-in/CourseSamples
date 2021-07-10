	.set sysarch, _x64_
	.include "console.i"

	.text

Summation:			#procedure identifier
	mov	rdx, rax
	add	rdx, 1
	mul	rdx
	shr	rax, 1

	ret			#transfers control to return address

	.entry	main
main:
	GetInt	askl, lower	
	GetInt	asku, upper	

	mov	rax, lower
	cmp	rax, upper
	jg	done	
	sub	rax, 1
	call	Summation	#transfers control to instruction labelled as Summation
				#along with return address (of next instruction)
	mov	rbx, rax
	mov	rax, upper
	call	Summation
	sub	rax, rbx

	PutInt	ans
done:	ret

askl:	.string "Lower Limit: "
asku:	.string "Upper Limit: "
ans:	.string "Sum of Positive Integers = "

	.data

lower:	.quad	0
upper:	.quad	0
	

	.end

