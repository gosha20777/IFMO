package TripleExpression;

public class Divide<T> extends BinaryOperator<T> implements TripleExpression<T> {
    public Divide(TripleExpression<T> first, TripleExpression<T> second, Operator<T> op) {
        super(first, second, op);
    }

    protected T apply(T a, T b) throws Exception {
        return op.divide(a, b);
    }
}