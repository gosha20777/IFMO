package TripleExpression;

public class Mod extends BinaryOperator implements TripleExpression {
    public Mod(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected int apply(int a, int b) {
        return a % b;
    }
}