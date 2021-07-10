package finance;

import java.lang.annotation.*;

@Retention(RetentionPolicy.RUNTIME)
@Target(ElementType.TYPE) //@Target({ElementType.FIELD, ElementType.METHOD})
public @interface MaxDuration {
	int value() default 4;
}

