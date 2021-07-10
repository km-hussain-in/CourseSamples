	.intel_syntax noprefix

	.text

	.global	GCD		#publishing GCD label so that it is visible to external code
	.type	GCD, @function	#GCD is a function (it follows calling convention)
GCD:
1:	cmp	rdi, rsi
	je	3f
	jg	2f
	sub	rsi, rdi
	jmp	1b
2:	sub	rdi, rsi
	jmp	1b
3:	mov	rax, rdi
	ret



	.end

