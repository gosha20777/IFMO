package TripleExpression;

public class CheckedMultiply extends BinaryOperator implements TripleExpression {
    public CheckedMultiply(TripleExpression first, TripleExpression second) {
        super(first, second);
    }

    protected void check(int a, int b) throws Exception {
        if (a > b) {
            check(b, a);
        } else {
            if (a < 0) {
                if (b < 0) {
                    if (a < Integer.MAX_VALUE / b) {
                        throw new OverflowException();
                    }
                } else if (b > 0) {
                    if (Integer.MIN_VALUE / b > a) {
                              throw new OverflowException();
                    }
                }          
            } else if (a > 0) {
                if (a > Integer.MAX_VALUE / b) {
                    throw new OverflowException();
                }
            }
        }
    } 
    protected int apply(int a, int b) throws Exception {
        check(a, b);
        return a * b;
    }
}