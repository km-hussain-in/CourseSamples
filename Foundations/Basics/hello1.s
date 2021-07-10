	.set sysarch, _x64_
	.include "console.i"

	.text
	#read-only memory section used for program code and constants

	.entry main
main:
	PutMsg	greet

	ret
	#instruction to return the control to the system

	.data
	#writable memory section used for program variables

greet:	.string	"Hello World!\n"
#greet label is linked to the location of a memory block containing ASCII codes
#of characters in "Hello World!\n"

	.end
:q

