package TripleExpression;

public class Mod<T> extends BinaryOperator<T> implements TripleExpression<T> {
    public Mod(TripleExpression<T> first, TripleExpression<T> second, Operator<T> op) {
        super(first, second, op);
    }

    protected T apply(T a, T b) throws Exception {
        return op.mod(a, b);
    }
}