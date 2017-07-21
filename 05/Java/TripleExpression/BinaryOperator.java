package TripleExpression;

abstract public class BinaryOperator implements TripleExpression {
    protected TripleExpression fOp;
    protected TripleExpression sOp;
    
    BinaryOperator(TripleExpression first, TripleExpression second) {
        fOp = first;
        sOp = second;
    }

    abstract protected double apply(double a, double b);
    
    public double evaluate(double x, double y, double z) {
        return apply(fOp.evaluate(x, y, z), sOp.evaluate(x, y, z));
    }
}