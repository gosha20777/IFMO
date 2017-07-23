package TripleExpression;

public class Const<T> implements TripleExpression<T> {
	private T value;
    public Const(T val) {
        value = val;
    }

    public T evaluate(T x, T y, T z) {
        return value;
    }
}