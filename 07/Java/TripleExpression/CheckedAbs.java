package TripleExpression;

public class CheckedAbs implements TripleExpression {
	private TripleExpression value;
    public CheckedAbs(TripleExpression val) {
        value = val;
    }

    protected void check(int a) throws Exception {
        if (a == Integer.MIN_VALUE) {
            throw new OverflowException();
        }
    }

    public int evaluate(int x, int y, int z) throws Exception {
        int val = value.evaluate(x, y, z);
        check(val);
        if(val < 0) {
            val = -val;
        }
        return val;
    }
}