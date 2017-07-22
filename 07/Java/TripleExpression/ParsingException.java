package TripleExpression;

public class ParsingException extends RuntimeException {
    public ParsingException() {}
    public ParsingException(String message) {
        super(message);
    }
}