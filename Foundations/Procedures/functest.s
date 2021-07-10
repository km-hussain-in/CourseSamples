	.file	"functest.c"
	.text
	.globl	Summation
	.type	Summation, @function
Summation:
.LFB0:
	.cfi_startproc
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	movl	%edi, -4(%rbp)
	movl	-4(%rbp), %eax
	addl	$1, %eax
	imull	-4(%rbp), %eax
	movl	%eax, %edx
	shrl	$31, %edx
	addl	%edx, %eax
	sarl	%eax
	cltq
	popq	%rbp
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE0:
	.size	Summation, .-Summation
	.section	.rodata
.LC0:
	.string	"Lower Limit: "
.LC1:
	.string	"%d"
.LC2:
	.string	"Upper Limit: "
	.align 8
.LC3:
	.string	"Sum of Positive Integers = %ld\n"
.LC4:
	.string	"ERROR: Invalid range!"
	.text
	.globl	main
	.type	main, @function
main:
.LFB1:
	.cfi_startproc
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	pushq	%rbx
	subq	$24, %rsp
	.cfi_offset 3, -24
	movq	$0, -24(%rbp)
	movl	$.LC0, %edi
	movl	$0, %eax
	call	printf
	leaq	-28(%rbp), %rax
	movq	%rax, %rsi
	movl	$.LC1, %edi
	movl	$0, %eax
	call	__isoc99_scanf
	movl	$.LC2, %edi
	movl	$0, %eax
	call	printf
	leaq	-32(%rbp), %rax
	movq	%rax, %rsi
	movl	$.LC1, %edi
	movl	$0, %eax
	call	__isoc99_scanf
	movl	-28(%rbp), %edx
	movl	-32(%rbp), %eax
	cmpl	%eax, %edx
	jge	.L4
	movl	-32(%rbp), %eax
	movl	%eax, %edi
	call	Summation
	movq	%rax, %rbx
	movl	-28(%rbp), %eax
	subl	$1, %eax
	movl	%eax, %edi
	call	Summation
	subq	%rax, %rbx
	movq	%rbx, %rax
	movq	%rax, -24(%rbp)
	movq	-24(%rbp), %rax
	movq	%rax, %rsi
	movl	$.LC3, %edi
	movl	$0, %eax
	call	printf
	jmp	.L6
.L4:
	movl	$.LC4, %edi
	call	puts
.L6:
	addq	$24, %rsp
	popq	%rbx
	popq	%rbp
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE1:
	.size	main, .-main
	.ident	"GCC: (GNU) 4.8.5 20150623 (Red Hat 4.8.5-36)"
	.section	.note.GNU-stack,"",@progbits
