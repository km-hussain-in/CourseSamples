#include "TaxPayerBridge.h"
#include "taxation.h"

JNIEXPORT jdouble JNICALL Java_TaxPayerBridge_getIncomeTax(JNIEnv* env, jobject obj, jshort age)
{
	jclass cls = env->GetObjectClass(obj);
	jfieldID idIncome = env->GetFieldID(cls, "income", "D");
	jdouble income = env->GetDoubleField(obj, idIncome);
	jmethodID idValidate = env->GetMethodID(cls, "validate", "(S)Z");
	jboolean valid = env->CallBooleanMethod(obj, idValidate, age);

	if(valid == JNI_TRUE)
	{
		Taxation::TaxPayer legacyObj(age);
		return legacyObj.IncomeTax(income);
	}

	jclass ex = env->FindClass("java/lang/IllegalArgumentException");
	env->ThrowNew(ex, "Invalid age");
}


