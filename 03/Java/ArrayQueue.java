public class ArrayQueue 
{
    private int size;
    private int head;
    private int tail;
	//private int capacity;
    private Object[] elements = new Object[10];

    private void fixCapacity(int capacity) 
	{
        int len = elements.length;
        if (capacity > len) 
		{
            Object[] newElements = new Object[elements.length * 2];
            int i = 0;
            while (tail!=head) 
			{
                newElements[i] = elements[head];
                head = (head + 1) % len;
                i++;
            }
            head = 0;
            tail = len - 1;
            elements = newElements;
        }
    }

    //pre: element != null
    //post: elements[tail] = element,
    //      tail = (tail + 1) % elements.length,
    //      size = size + 1 
    public void enqueue(Object element) 
	{
        assert element != null;
        fixCapacity(size + 2);
        elements[tail] = element;
        tail = (tail + 1) % elements.length;
        size++;
    }

    
    //pre: size > 0
    //post: R = elements[head]
    public Object element() 
	{
        assert size > 0;
        return elements[head];
    }

    //pre: size > 0
    //post: R = elements[head],
    //      head = (head + 1) % elements.length,
    //      size = size - 1 
    public Object dequeue() 
	{
        Object ret = element();
        elements[head] = null;
        head = (head + 1) % elements.length;
        size--;
        return ret;
    }

    //post: R = size
    public int size() 
	{
        return size;
    }

    //post: R = (size == 0)
    public boolean isEmpty() 
	{
        return (size == 0);
    }

    //post: size = 0,
    //      head = 0,
    //      tail = 0,
    public void clear() 
	{
        head = 0;
        tail = 0;
        size = 0;
    }

    //pre: element != null
    //post: (head - 1 < 0) ? head = elements.length - 1 : head = head - 1,
    //      elements[head] = element,
    //      size = size + 1;
    public void push(Object element) 
	{
        assert element != null;
        fixCapacity(size + 2);
        head = head - 1;
        if (head < 0) 
		{
            head = elements.length - 1;
        }
        elements[head] = element;
        size++;
    }

    //pre: size > 0;
    //post: R = elements[(tail - 1 < 0) ? elements.length - 1 : tail - 1]
    public Object peek() 
	{
        assert size > 0;
        int ltail = tail - 1;
        if (ltail < 0) 
		{
            ltail = elements.length - 1;
        }
        return elements[ltail];
    }

    //pre: size > 0;
    //post: (tail - 1 < 0) ? tail = elements.length - 1 : tail = tail - 1,
    //      R = elements[tail]   
    public Object remove() 
	{
        assert size > 0;
        tail = tail - 1;
        if (tail < 0) 
		{
            tail = elements.length - 1;
        }
        Object ret = elements[tail];
        elements[tail] = null;
        size--;
        return ret;
    }
}