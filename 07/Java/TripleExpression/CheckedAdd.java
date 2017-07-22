package TripleExpression;

public class CheckedAdd extends BinaryOperator implements TripleExpression {
    public CheckedAdd(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected void check(int a, int b) throws Exception {
        if (a > 0 && b > Integer.MAX_VALUE - a) {
            throw new OverflowException();    
        }
        if (a < 0 &&  b < Integer.MIN_VALUE - a) {
            throw new OverflowException();
        }
    }

    protected int apply(int a, int b) throws Exception {
        check(a, b);
        return a + b;
    }
}