package TripleExpression;

public class Multiply extends BinaryOperator implements TripleExpression {
    public Multiply(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected double apply(double a, double b) {
        return a * b;
    }
}