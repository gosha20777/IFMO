package Expression;

public class Add extends BinaryOperator implements Expression {
    public Add(Expression first, Expression second) {
        fOp = first;
        sOp = second;
    }

    public double evaluate(double param) {
        return fOp.evaluate(param) + sOp.evaluate(param);
    }
}