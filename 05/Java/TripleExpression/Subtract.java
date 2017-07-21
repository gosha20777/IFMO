package TripleExpression;

public class Subtract extends BinaryOperator implements TripleExpression {
    public Subtract(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected double apply(double a, double b) {
        return a - b;
    }
}