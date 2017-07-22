package TripleExpression;

public class CheckedSqrt implements TripleExpression {
    private TripleExpression value;
    public CheckedSqrt(TripleExpression val) {
        value = val;
    }

    private void check(int a) throws Exception {
        if (a < 0) {
            throw new ParsingException("sqrt from negative number");
        }
    }

    public int evaluate(int x, int y, int z) throws Exception {
        int a = value.evaluate(x, y, z);
        check(a);
        int l = -1;
        int r = 46341;
        while (r - l > 1) {
            int m = (l + r) / 2;
            if (m*m <= a) {
                l = m;
            } else {
                r = m;
            }
        }
        return l;
    }
}