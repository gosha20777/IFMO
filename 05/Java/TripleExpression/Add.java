package TripleExpression;

public class Add extends BinaryOperator implements TripleExpression {
    public Add(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected double apply(double a, double b) {
        return a + b;
    }
}