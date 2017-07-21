package Expression;

public class Divide extends BinaryOperator implements Expression {
    public Divide(Expression first, Expression second) {
        fOp = first;
        sOp = second;
    }

    public double evaluate(double param) {
        return fOp.evaluate(param) / sOp.evaluate(param);
    }
}