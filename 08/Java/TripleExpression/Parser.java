package TripleExpression;

public interface Parser<T> {
    TripleExpression<T> parse(String expression) throws Exception;
}