package TripleExpression;

public class Subtract<T> extends BinaryOperator<T> implements TripleExpression<T> {
    public Subtract(TripleExpression<T> first, TripleExpression<T> second, Operator<T> op) {
        super(first, second, op);
    }

    protected T apply(T a, T b) throws Exception {
        return op.subtract(a, b);
    }
}