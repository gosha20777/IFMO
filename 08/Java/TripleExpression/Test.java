package TripleExpression;

public class Test {
	public static void main(String[] args) {
        ExpressionParser<Integer> parser = new ExpressionParser<>(new OpInteger());
        try {
            System.out.println(parser.parse(args[0]).evaluate(2, 1, 1));
        } catch (Exception e) {
            System.out.println(e.getMessage());
        }
	}
}