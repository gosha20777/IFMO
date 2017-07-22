package TripleExpression;

abstract public class BinaryOperator implements TripleExpression {
    protected TripleExpression fOp;
    protected TripleExpression sOp;
    
    BinaryOperator(TripleExpression first, TripleExpression second) {
        fOp = first;
        sOp = second;
    }

    abstract protected int apply(int a, int b) throws Exception;
    
    public int evaluate(int x, int y, int z) throws Exception {
        return apply(fOp.evaluate(x, y, z), sOp.evaluate(x, y, z));
    }
}