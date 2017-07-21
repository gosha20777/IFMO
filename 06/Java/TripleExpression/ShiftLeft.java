package TripleExpression;

public class ShiftLeft extends BinaryOperator implements TripleExpression {
    public ShiftLeft(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected int apply(int a, int b) {
        return a << b;
    }
}