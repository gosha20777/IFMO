package TripleExpression;

public class ShiftRight extends BinaryOperator implements TripleExpression {
    public ShiftRight(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected int apply(int a, int b) {
        return a >> b;
    }
}