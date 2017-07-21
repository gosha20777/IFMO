package TripleExpression;

public class Abs implements TripleExpression {
	private TripleExpression value;
    public Abs(TripleExpression val) {
        value = val;
    }

    public int evaluate(int x, int y, int z) {
        return Math.abs(value.evaluate(x, y, z));
    }
}