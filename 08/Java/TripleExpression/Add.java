package TripleExpression;

public class Add<T> extends BinaryOperator<T> implements TripleExpression<T> {
    public Add(TripleExpression<T> first, TripleExpression<T> second, Operator<T> op) {
        super(first, second, op);
    }

    protected T apply(T a, T b) throws Exception {
        return op.add(a, b);
    }
}