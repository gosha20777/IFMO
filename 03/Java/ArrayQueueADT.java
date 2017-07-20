public class ArrayQueueADT 
{
    private int size;
    private int head;
    private int tail;
	//private int capacity;
    private Object[] elements = new Object[10];

    static void fixCapacity(ArrayQueueADT queue, int capacity) 
	{
        assert queue != null;
        int len = queue.elements.length;
        if (capacity > len) 
		{
            Object[] newElements = new Object[queue.elements.length * 2];
            int i = 0;
            while (queue.tail!=queue.head) 
			{
                newElements[i] = queue.elements[queue.head];
                queue.head = (queue.head + 1) % len;
                i++;
            }
            queue.head = 0;
            queue.tail = len - 1;
            queue.elements = newElements;
        }
    }

    //pre: element != null,
    //     queue != null
    //post: elements[tail] = element,
    //      tail = (tail + 1) % elements.length,
    //      size = size + 1
    public static void enqueue(ArrayQueueADT queue, Object element) 
	{
        assert queue != null;
        assert element != null;
        fixCapacity(queue, queue.size + 2);
        queue.elements[queue.tail] = element;
        queue.tail = (queue.tail + 1) % queue.elements.length;
        queue.size++;
        //System.out.println(elements.length);
    }

    //pre: queue != null,
    //     size > 0
    //post: R = elements[head]
    public static Object element(ArrayQueueADT queue) 
	{
        assert queue != null;
        assert queue.size > 0;
        return queue.elements[queue.head];
    }

    //pre: queue != null,
    //     size > 0
    //post: R = elements[head],
    //      head = (head + 1) % elements.length,
    //      size = size - 1
    public static Object dequeue(ArrayQueueADT queue) 
	{
        assert queue != null;
        Object ret = element(queue);
        queue.elements[queue.head] = null;
        queue.head = (queue.head + 1) % queue.elements.length;
        queue.size--;
        return ret;
    }

    //pre: queue != null
    //post: R = size
    public static int size(ArrayQueueADT queue)
	{
        assert queue != null;
        return queue.size;
    }

    //pre: queue != null
    //post: R = (size == 0)
    public static boolean isEmpty(ArrayQueueADT queue)
	{
        assert queue != null;
        return (queue.size == 0);
    }

    //pre: queue != null
    //post: size = 0,
    //      head = 0,
    //      tail = 0
    public static void clear(ArrayQueueADT queue) 
	{
        assert queue != null;
        queue.head = 0;
        queue.tail = 0;
        queue.size = 0;
    }

    //pre: queue != null,
    //     element != null
    //post: (head - 1 < 0) ? head = elements.length - 1 : head = head - 1,
    //      elements[head] = element,
    //      size = size + 1;
    public static void push(ArrayQueueADT queue, Object element) 
	{
        assert queue != null;
        assert element != null;
        fixCapacity(queue, queue.size + 2);
        queue.head = queue.head - 1;
        if (queue.head < 0) {
            queue.head = queue.elements.length - 1;
        }
        queue.elements[queue.head] = element;
        queue.size++;
    }

    //pre: queue != null,
    //     size > 0;
    //post: R = elements[(tail - 1 < 0) ? elements.length - 1 : tail - 1]
    public static Object peek(ArrayQueueADT queue) 
	{
        assert queue != null;
        assert queue.size > 0;
        int ltail = queue.tail - 1;
        if (ltail < 0) {
            ltail = queue.elements.length - 1;
        }
        return queue.elements[ltail];
    }

    //pre: queue!= null,
    //     size > 0;
    //post: (tail - 1 < 0) ? tail = elements.length - 1 : tail = tail - 1,
    //      R = elements[tail]   
    public static Object remove(ArrayQueueADT queue) 
	{
        assert queue != null;
        assert queue.size > 0;
        queue.tail = queue.tail - 1;
        if (queue.tail < 0) 
		{
            queue.tail = queue.elements.length - 1;
        }
        Object ret = queue.elements[queue.tail];
        queue.elements[queue.tail] = null;
        queue.size--;
        return ret;
    }
}