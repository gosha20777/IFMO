package TripleExpression;

public class Test {
	public static void main(String[] args) {
        ExpressionParser parser = new ExpressionParser();
        System.out.println(parser.parse(args[0]).evaluate(2, 1, 1));
	}
}