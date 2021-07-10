	.file	"funcovldtest.cpp"
	.local	_ZStL8__ioinit
	.comm	_ZStL8__ioinit,1,1
	.text
	.globl	_Z7Computeiis
	.type	_Z7Computeiis, @function
_Z7Computeiis:
.LFB971:
	.cfi_startproc
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	movl	%edi, -20(%rbp)
	movl	%esi, -24(%rbp)
	movl	%edx, %eax
	movw	%ax, -28(%rbp)
	movq	$0, -8(%rbp)
	movl	-20(%rbp), %eax
	movl	%eax, -12(%rbp)
	jmp	.L2
.L3:
	movl	-12(%rbp), %eax
	imull	-12(%rbp), %eax
	cltq
	addq	%rax, -8(%rbp)
	movswl	-28(%rbp), %eax
	addl	%eax, -12(%rbp)
.L2:
	movl	-12(%rbp), %eax
	cmpl	-24(%rbp), %eax
	jle	.L3
	movq	-8(%rbp), %rax
	popq	%rbp
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE971:
	.size	_Z7Computeiis, .-_Z7Computeiis
	.globl	_Z7Computeis
	.type	_Z7Computeis, @function
_Z7Computeis:
.LFB972:
	.cfi_startproc
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	subq	$8, %rsp
	movl	%edi, -4(%rbp)
	movl	%esi, %eax
	movw	%ax, -8(%rbp)
	movswl	-8(%rbp), %edx
	movl	-4(%rbp), %eax
	movl	%eax, %esi
	movl	$1, %edi
	call	_Z7Computeiis
	leave
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE972:
	.size	_Z7Computeis, .-_Z7Computeis
	.section	.rodata
.LC0:
	.string	"Lower and Upper Limit: "
.LC1:
	.string	"Increment: "
.LC2:
	.string	"Your Computation Result = "
.LC3:
	.string	"Simple Computation Result = "
	.text
	.globl	main
	.type	main, @function
main:
.LFB973:
	.cfi_startproc
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	pushq	%rbx
	subq	$24, %rsp
	.cfi_offset 3, -24
	movl	$.LC0, %esi
	movl	$_ZSt4cout, %edi
	call	_ZStlsISt11char_traitsIcEERSt13basic_ostreamIcT_ES5_PKc
	leaq	-20(%rbp), %rax
	movq	%rax, %rsi
	movl	$_ZSt3cin, %edi
	call	_ZNSirsERi
	leaq	-24(%rbp), %rdx
	movq	%rdx, %rsi
	movq	%rax, %rdi
	call	_ZNSirsERi
	movl	$.LC1, %esi
	movl	$_ZSt4cout, %edi
	call	_ZStlsISt11char_traitsIcEERSt13basic_ostreamIcT_ES5_PKc
	leaq	-26(%rbp), %rax
	movq	%rax, %rsi
	movl	$_ZSt3cin, %edi
	call	_ZNSirsERs
	movzwl	-26(%rbp), %eax
	movswl	%ax, %edx
	movl	-24(%rbp), %ecx
	movl	-20(%rbp), %eax
	movl	%ecx, %esi
	movl	%eax, %edi
	call	_Z7Computeiis
	movq	%rax, %rbx
	movl	$.LC2, %esi
	movl	$_ZSt4cout, %edi
	call	_ZStlsISt11char_traitsIcEERSt13basic_ostreamIcT_ES5_PKc
	movq	%rbx, %rsi
	movq	%rax, %rdi
	call	_ZNSolsEl
	movl	$_ZSt4endlIcSt11char_traitsIcEERSt13basic_ostreamIT_T0_ES6_, %esi
	movq	%rax, %rdi
	call	_ZNSolsEPFRSoS_E
	movl	-24(%rbp), %eax
	movl	$1, %esi
	movl	%eax, %edi
	call	_Z7Computeis
	movq	%rax, %rbx
	movl	$.LC3, %esi
	movl	$_ZSt4cout, %edi
	call	_ZStlsISt11char_traitsIcEERSt13basic_ostreamIcT_ES5_PKc
	movq	%rbx, %rsi
	movq	%rax, %rdi
	call	_ZNSolsEl
	movl	$_ZSt4endlIcSt11char_traitsIcEERSt13basic_ostreamIT_T0_ES6_, %esi
	movq	%rax, %rdi
	call	_ZNSolsEPFRSoS_E
	movl	$0, %eax
	addq	$24, %rsp
	popq	%rbx
	popq	%rbp
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE973:
	.size	main, .-main
	.type	_Z41__static_initialization_and_destruction_0ii, @function
_Z41__static_initialization_and_destruction_0ii:
.LFB983:
	.cfi_startproc
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	subq	$16, %rsp
	movl	%edi, -4(%rbp)
	movl	%esi, -8(%rbp)
	cmpl	$1, -4(%rbp)
	jne	.L9
	cmpl	$65535, -8(%rbp)
	jne	.L9
	movl	$_ZStL8__ioinit, %edi
	call	_ZNSt8ios_base4InitC1Ev
	movl	$__dso_handle, %edx
	movl	$_ZStL8__ioinit, %esi
	movl	$_ZNSt8ios_base4InitD1Ev, %edi
	call	__cxa_atexit
.L9:
	leave
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE983:
	.size	_Z41__static_initialization_and_destruction_0ii, .-_Z41__static_initialization_and_destruction_0ii
	.type	_GLOBAL__sub_I__Z7Computeiis, @function
_GLOBAL__sub_I__Z7Computeiis:
.LFB984:
	.cfi_startproc
	pushq	%rbp
	.cfi_def_cfa_offset 16
	.cfi_offset 6, -16
	movq	%rsp, %rbp
	.cfi_def_cfa_register 6
	movl	$65535, %esi
	movl	$1, %edi
	call	_Z41__static_initialization_and_destruction_0ii
	popq	%rbp
	.cfi_def_cfa 7, 8
	ret
	.cfi_endproc
.LFE984:
	.size	_GLOBAL__sub_I__Z7Computeiis, .-_GLOBAL__sub_I__Z7Computeiis
	.section	.init_array,"aw"
	.align 8
	.quad	_GLOBAL__sub_I__Z7Computeiis
	.hidden	__dso_handle
	.ident	"GCC: (GNU) 4.8.5 20150623 (Red Hat 4.8.5-36)"
	.section	.note.GNU-stack,"",@progbits
