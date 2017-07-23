package TripleExpression;

public class OpDouble implements Operator<Double> {
    public Double parse(String a) {
        return Double.parseDouble(a);
    }
    public Double add(Double a, Double b) throws Exception {
        return a + b;
    }
    public Double subtract(Double a, Double b) throws Exception {
        return a - b;
    }
    public Double multiply(Double a, Double b) throws Exception {
        return a * b;
    }
    public Double divide(Double a, Double b) throws Exception {
        return a / b;
    }
    public Double negate(Double a) throws Exception {
        return -a;
    }
    public Double mod(Double a, Double b) throws Exception {
        return a % b;
    }
    public Double abs(Double a) throws Exception{
        if (a < 0) {
            return -a;
        } else {
            return a;
        }
    }
    public Double square(Double a) throws Exception {
        return a*a;
    }
}