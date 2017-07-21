package TripleExpression;

public class Subtract extends BinaryOperator implements TripleExpression {
    public Subtract(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected int apply(int a, int b) {
        return a - b;
    }
}