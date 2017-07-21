package TripleExpression;

public class Add extends BinaryOperator implements TripleExpression {
    public Add(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected int apply(int a, int b) {
        return a + b;
    }
}