#ifndef _CONSOLE_H
#define _CONSOLE_H

#ifdef __cplusplus
extern "C"{
#endif

int main(void);

#if defined(__amd64__)

void _x64_writestr(const char*, long);
void _x64_writechr(char);
void _x64_writeint(long);
long _x64_readint(void);

#ifndef _NO_SYSSTART
void _x64_start(int(*)());
void _start(void)
{
	_x64_start(main);	
}
#endif

long GetInt(const char* prompt)
{	
	_x64_writestr(prompt, 0);
	return _x64_readint();
}

#define PutMsg(txt) _x64_writestr(txt, 0)
#define PutInt(pmt, val) _x64_writestr(pmt, 0);_x64_writeint(val);_x64_writechr('\n')

#elif defined(__aarch64__)

void _a64_writestr(const char*, long);
void _a64_writeint(long);
void _a64_writechr(char);
long _a64_readint(void);

#ifndef _NO_SYSSTART
void _a64_start(int(*)());
void _start(void)
{
	_a64_start(main);	
}
#endif

long GetInt(const char* prompt)
{
	_a64_writestr(prompt, 0);
	return _a64_readint();
}

#define PutMsg(txt) _a64_writestr(txt, 0)
#define PutInt(pmt, val) _a64_writestr(pmt, 0);_a64_writeint(val);_a64_writechr('\n')

#else
#error Unsupported machine architecture

#endif

#ifdef __cplusplus
}
#endif

#endif
