package TripleExpression;

public class Divide extends BinaryOperator implements TripleExpression {
    public Divide(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected double apply(double a, double b) {
        return a / b;
    }
}