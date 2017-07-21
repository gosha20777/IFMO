import java.util.function.Predicate;
import java.util.function.Function;

abstract public class AbstractQueue implements Queue {

    abstract public void enqueue(Object element);

    abstract public Object element();
    
    abstract public Object dequeue();
    
    abstract public void clear();

    abstract public int size();

    abstract public boolean isEmpty();

    abstract public AbstractQueue makeCopy();

    public AbstractQueue filter(Predicate<Object> predicate) {
        AbstractQueue ret = makeCopy();
        int s = ret.size();

        for (int i = 0; i < s; i++) {
            Object elem = ret.dequeue();
            if (predicate.test(elem)) {
                ret.enqueue(elem);
            }
        }

        return ret;
    }

    public AbstractQueue map(Function<Object, Object> func) {
        AbstractQueue ret = makeCopy();
        int s = ret.size();
        for (int i = 0; i < s; i++) {
            ret.enqueue(func.apply(ret.dequeue()));
        }

        return ret;
    }
}