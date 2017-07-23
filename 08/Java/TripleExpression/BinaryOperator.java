package TripleExpression;

abstract public class BinaryOperator<T> implements TripleExpression<T> {
    protected TripleExpression<T> fOp;
    protected TripleExpression<T> sOp;

    Operator<T> op;
    
    BinaryOperator(TripleExpression<T> first, TripleExpression<T> second, Operator<T> op) {
        fOp = first;
        sOp = second;
        this.op = op;
    }

    abstract protected T apply(T a, T b) throws Exception;
    
    public T evaluate(T x, T y, T z) throws Exception {
        return apply(fOp.evaluate(x, y, z), sOp.evaluate(x, y, z));
    }
}