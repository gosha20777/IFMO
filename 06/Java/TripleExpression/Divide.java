package TripleExpression;

public class Divide extends BinaryOperator implements TripleExpression {
    public Divide(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected int apply(int a, int b) {
        return a / b;
    }
}