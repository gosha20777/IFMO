package Expression;

public class Main {
    public static void main(String[] args) {
        assert args.length >= 1;
        double arg = Double.parseDouble(args[0]);
        System.out.println(new Add(new Subtract(new Multiply(new Variable("x"), new Variable("x")), new Multiply(new Const(2), new Variable("x"))), new Const(1)).evaluate(arg));
    }
}