####################################################################
# Name          : console.i
# Description   : Defines macros for interfacing with system
# Author        : K.M.Hussain
# Licence       : Educational
#####################################################################

.set   _x64_, 0x8664
.set   _a64_, 0x0A64

.ifdef sysarch
.set sysprefix, sysarch
.endif

.ifndef sysprefix
.error  "Unknown system"
.else
.ifeq sysprefix-_x64_
.intel_syntax noprefix
.else
.if sysprefix-_a64_
.error  "Invalid system"
.endif
.endif
.endif

# PutMsg - Outputs a string.
.macro  PutMsg  value, len
        .ifeq sysprefix-_x64_
        push    %rdi
        push    %rsi
        .ifnb   \len
        mov     %rsi, \len
        mov     %rdi, \value
        .else
        mov     %rsi, 0
        mov     %rdi, offset \value
        .endif
        call    _x64_writestr
        pop     %rsi
        pop     %rdi
        .else
        .ifeq   sysprefix-_a64_
        stp    x0, x30, [sp, -16]!
        stp    x1, x2, [sp, -16]!
        .ifnb   \len
        mov     x0, \value
        mov     x1, \len
        .else
        ldr     x0, =\value
        mov     x1, 0
        .endif
        bl      _a64_writestr
        ldp     x1, x2, [sp], 16
        ldp     x0, x30, [sp], 16
        .endif
        .endif
.endm

# PutInt - Outputs a quad-word integer value.
.macro  PutInt  prompt, value, disp
        .ifnb   \prompt
        PutMsg  \prompt
        .endif
        .ifeq sysprefix-_x64_
        push    %rdi
        .ifnb   \value
        mov     %rdi, [\value]
        .else
        mov     %rdi, %rax
        .endif
        call    _x64_writeint
        mov     %rdi, '\n'
        call    _x64_writechr
        pop     %rdi
        .else
        .ifeq sysprefix-_a64_
        stp    x0, x30, [sp, -16]!
        .ifnb   \disp
        ldr     x0, [\value, \disp]
        .else 
        .ifnb   \value
        ldr     x0, =\value
        ldr     x0, [x0]
        .endif
        .endif
        bl      _a64_writeint
        mov     x0, '\n'
        bl      _a64_writechr    
        ldp     x0, x30, [sp], 16
        .endif
        .endif
.endm

# GetInt - Inputs a quad-word integer value. 
.macro  GetInt prompt, value, disp
        .ifnb   \prompt
        PutMsg  \prompt
        .endif
        .ifeq sysprefix-_x64_
        .ifnb   \value
        push    %rax
        .endif
        call    _x64_readint
        .ifnb   \value
        mov     [\value], %rax
        pop     %rax
        .endif
        .else
        .ifeq sysprefix-_a64_
        .ifnb   \value
        stp     x0, x30, [sp, -16]!
        .else
        stp     x29, x30, [sp, -16]!
        .endif
        bl      _a64_readint
        .ifnb   \disp
        str     x0, [\value, \disp]
        .else
        .ifnb   \value
        ldr     x30, =\value
        str     x0, [x30]
        .endif
        .endif
        .ifnb   \value
        ldp     x0, x30, [sp], 16
        .else
        ldp     x29, x30, [sp], 16
        .endif
        .endif
        .endif
.endm

# PutDec - Outputs a fixed-point decimal value.
.macro  PutDec  prompt, value, disp
        .ifnb   \prompt
        PutMsg  \prompt
        .endif
        .ifeq sysprefix-_x64_
        .ifnb   \value
        sub     %rsp, 16
        movdqu  [%rsp], %xmm0
        movsd   %xmm0, [\value]
        .endif
        call    _x64_writedec
        push    %rdi
        mov     %rdi, '\n'
        call    _x64_writechr
        pop     %rdi
        .ifnb   \value
        movdqu  %xmm0, [%rsp]
        add     %rsp, 16
        .endif
        .else
        .ifeq sysprefix-_a64_
        stp    x0, x30, [sp, -16]!
        stp    d0, d1, [sp, -16]!
        .ifnb   \disp
        ldr     d0, [\value, \disp]
        .else 
        .ifnb   \value
        ldr     x0, =\value
        ldr     d0, [x0]
        .endif
        .endif
        bl      _a64_writedec
        mov     x0, '\n'
        bl      _a64_writechr     
        ldp     d0, d1, [sp], 16
        ldp     x0, x30, [sp], 16
        .endif
        .endif
.endm

# GetDec - Inputs a fixed-point decimal value.
.macro  GetDec  prompt, value, disp
        .ifnb   \prompt
        PutMsg  \prompt
        .endif
        .ifeq sysprefix-_x64_
        .ifnb   \value
        sub     %rsp, 16
        movdqu  [%rsp], %xmm0
        .endif
        call    _x64_readdec
        .ifnb   \value
        movsd     [\value], %xmm0
        movdqu  %xmm0, [%rsp]
        add     %rsp, 16
        .endif
        .else
        .ifeq sysprefix-_a64_
        .ifnb   \value
        stp     x0, x30, [sp, -16]!
        stp     d0, d1, [sp, -16]!
        .else
        stp     x29, x30, [sp, -16]!
        .endif
        bl      _a64_readdec
        .ifnb   \disp
        str     d0, [\value, \disp]
        .else
        .ifnb   \value
        ldr     x0, =\value
        str     d0, [x0]
        .endif
        .endif
        .ifnb   \value
        ldp     d0, d1, [sp], 16
        ldp     x0, x30, [sp], 16
        .else
        ldp     x29, x30, [sp], 16
        .endif
        .endif
        .endif
.endm

.set    as_int, 1
.set    as_dec, 2

# CmdArg - Get command line argument
.macro CmdArg   src, mode=0
        .ifeq sysprefix-_x64_
        push    %rdi
        .ifb    \src
        mov     %rdi, -1
        .else
        mov     %rdi, \src
        .endif
        .ifeq \mode-1
        call    _x64_argvint
        .else
        .ifeq   \mode-2
        call    _x64_argvdec
        .else
        call    _x64_startarg
        .endif
        .endif
        pop     %rdi 
        .else
        .ifeq sysprefix-_a64_
        stp    xzr, x30, [sp, -16]!
        .ifb    \src
        mov     x0, -1
        .else
        mov     x0, \src
        .endif
        .ifeq \mode-1
        bl   _a64_argvint
        .else
        .ifeq   \mode-2
        bl    _a64_argvdec
        .else
        bl    _a64_startarg
        .endif
        .endif
        ldp    xzr, x30, [sp], 16
        .endif
        .endif
.endm

.macro  .entry  point
.align  8
.global _start
_start:
        .ifeq sysprefix-_x64_
        mov     %rdi, offset \point     
        jmp    _x64_start+4
        .else
        .ifeq sysprefix-_a64_
        ldr     x0, =\point
        b       _a64_start
        .endif
        .endif
.endm

