using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueApp
{
    public class ArrayQueue : AbstractQueue
    {
        private Object[] array;
        private int size;
        private int capacity;
        private const int _defaultCapacity = 10;
        private int head;
        private int tail;

        public ArrayQueue(int size)
        {
            if (size < 1)
                throw new InvalidOperationException("ERROR: size < 1!");

            array = new Object[size];
            capacity = size;
            this.size = 0;
            head = -1;
            tail = 0;
        }
        public ArrayQueue()
        {
            array = new Object[_defaultCapacity];
            capacity = _defaultCapacity;
            size = 0;
            head = -1;
            tail = 0;
        }
        override public bool IsEmpty()
        {
            return size == 0;
        }
        override public void Enqueue(Object newElement)
        {
            if (size == capacity)
            {
                Object[] newQueue = new Object[2 * capacity];
                Array.Copy(array, 0, newQueue, 0, array.Length);
                array = newQueue;
                capacity *= 2;
                newQueue = null;
            }
            size++;
            array[tail++ % capacity] = newElement ?? throw new InvalidOperationException("ERROR: NULL elenent!");
        }
        override public Object Dequeue()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("ERROR: Empty queue!");
            }
            size--;
            return array[++head % capacity];
        }
        override public Object Element()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("ERROR: Empty queue!");
            }
            return array[head + 1 % capacity];
        }
        override public void Clear()
        {
            while (size != 0)
                Dequeue();
        }
        override public int Size()
        {
            return size;
        }
        public int Count
        {
            get
            {
                return size;
            }
        }
        public Object[] ToArray()
        {
            if (IsEmpty())
                throw new InvalidOperationException("ERROR: NULL elenent!");

            Object[] rezult = new Object[size];
            Array.Copy(array, head + 1 % capacity, rezult, 0, size);
            return rezult;
        }
    }
}
