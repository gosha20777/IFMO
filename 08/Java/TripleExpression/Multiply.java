package TripleExpression;

public class Multiply<T> extends BinaryOperator<T> implements TripleExpression<T> {
    public Multiply(TripleExpression<T> first, TripleExpression<T> second, Operator<T> op) {
        super(first, second, op);
    }

    protected T apply(T a, T b) throws Exception {
        return op.multiply(a, b);
    }
}