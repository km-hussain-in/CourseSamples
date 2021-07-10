#include "NativeMethodTest1.h"

JNIEXPORT jlong JNICALL Java_NativeMethodTest1_gcd(JNIEnv*, jclass, jlong first, jlong second)
{
	while(first != second) 
	{
		if(first > second)
			first -= second;
		else
			second -= first;
	}

	return first;
}

JNIEXPORT jstring JNICALL Java_NativeMethodTest1_reverseOf(JNIEnv* env, jclass, jstring text)
{
	jint n = env->GetStringLength(text);
	jchar* buffer = new jchar[n];

	env->GetStringRegion(text, 0, n, buffer);
	for(jint i = 0, j = n - 1; i < j; ++i, j--)
	{
		jchar ic = buffer[i];
		jchar jc = buffer[j];
		buffer[i] = jc;
		buffer[j] = ic;
	}

	jstring result = env->NewString(buffer, n);
	delete[] buffer;

	return result;
}

JNIEXPORT jint JNICALL Java_NativeMethodTest1_squareAll(JNIEnv* env, jclass, jdoubleArray list)
{
	jint n = env->GetArrayLength(list);
	jdouble* values = new jdouble[n];

	env->GetDoubleArrayRegion(list, 0, n, values);
	for(jint i = 0; i < n; ++i)
		values[i] *= values[i];
	env->SetDoubleArrayRegion(list, 0, n, values);
	delete[] values;

	return n;
}

