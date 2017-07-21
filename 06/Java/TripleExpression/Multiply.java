package TripleExpression;

public class Multiply extends BinaryOperator implements TripleExpression {
    public Multiply(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected int apply(int a, int b) {
        return a * b;
    }
}