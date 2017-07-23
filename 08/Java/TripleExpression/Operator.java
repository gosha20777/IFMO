package TripleExpression;

public interface Operator<T> {
    T parse(String a) throws Exception;
    T add(T a, T b) throws Exception;
    T subtract(T a, T b) throws Exception;
    T multiply(T a, T b) throws Exception;
    T divide(T a, T b) throws Exception;
    T mod(T a, T b) throws Exception;
    T negate(T a) throws Exception;
    T abs(T a) throws Exception;
    T square(T a) throws Exception;
}