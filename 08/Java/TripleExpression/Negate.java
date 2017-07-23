package TripleExpression;

public class Negate<T> implements TripleExpression<T> {
	private TripleExpression<T> value;
    private Operator<T> op;
    public Negate(TripleExpression<T> val, Operator<T> op) {
        value = val;
        this.op = op;
    }

    public T evaluate(T x, T y, T z) throws Exception {
        T a = value.evaluate(x, y, z);
        return op.negate(a);
    }
}