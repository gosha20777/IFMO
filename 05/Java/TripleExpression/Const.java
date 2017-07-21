package TripleExpression;

public class Const implements TripleExpression {
	private double value;
    public Const(double val) {
        value = val;
    }

    public double evaluate(double x, double y, double z) {
        return value;
    }
}