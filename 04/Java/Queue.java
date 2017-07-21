import java.util.function.Predicate;
import java.util.function.Function;

public interface Queue {
    //pre: element != null
    //post: size = size + 1,
    //      element inserted at the end of queue
    void enqueue(Object element);

    //pre: size > 0
    //post: R = first element in queue;
    Object element();

    //pre: size > 0;
    //post: size = size - 1,
    //      first element of queue deleted
    Object dequeue();

    //post: R = size
    int size();

    //post: R = (size == 0)
    boolean isEmpty();

    //post: size = 0
    //      delete all queue elements
    void clear();

    Queue makeCopy();

    //post: R = queue of elements of class instance matching predicate
    Queue filter(Predicate<Object> predicate);

    //post: R = queue of elements of class instance with func applied to them
    Queue map(Function<Object, Object> func);
}