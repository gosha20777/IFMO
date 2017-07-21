package TripleExpression;

public class Square implements TripleExpression {
	private TripleExpression value;
    public Square(TripleExpression val) {
        value = val;
    }

    public int evaluate(int x, int y, int z) {
        int a = value.evaluate(x, y, z);
        return a * a;
    }
}