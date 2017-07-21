using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueApp
{
    public class LinkedQueue : AbstractQueue 
    {
        private ListNode head;
        private ListNode tail;
        private int size;
        override public void Enqueue(Object element)
        {
            if (element == null)
                throw new InvalidOperationException("element = nul!");

            head = new ListNode(element, null, head);
            if (head.next != null)
            {
                head.next.prev = head;
            }
            if (size == 0)
            {
                tail = head;
            }
            size++;
        }

        override public Object Element()
        {
            if (size <= 0)
                throw new InvalidOperationException("size < 0");
            return tail.value;
        }

        override public Object Dequeue()
        {
            Object ret = Element();
            if (tail.prev != null)
            {
                tail = tail.prev;
                tail.next = null;
            }
            else
            {
                tail = null;
            }
            size--;
            return ret;
        }

        override public void Clear()
        {
            ListNode node = head;
            while (node != null)
            {
                ListNode newNode = node.next;
                node = null;
                node = newNode;
            }
            size = 0;
        }

        public void Push(Object element)
        {
            if (element == null)
                throw new InvalidOperationException("element = nul!");
            tail = new ListNode(element, tail, null);
            if (tail.prev != null)
            {
                tail.prev.next = tail;
            }
            if (size == 0)
            {
                head = tail;
            }
            size++;
        }

        public Object Peek()
        {
            if (size <= 0)
                throw new InvalidOperationException("size <= 0");
            return head.value;
        }

        public Object Remove()
        {
            if (size <= 0)
                throw new InvalidOperationException("size <= 0");
            Object ret = Peek();
            if (head.next != null)
            {
                head = head.next;
                head.prev = null;
            }
            else
            {
                head = null;
            }
            size--;
            return ret;
        }

        override public int Size()
        {
            return size;
        }

        override public bool IsEmpty()
        {
            return (size == 0);
        }

        public LinkedQueue MakeCopy()
        {
            LinkedQueue copy = new LinkedQueue();
            ListNode node = tail;
            while (node != null)
            {
                copy.Enqueue(node.value);
                node = node.prev;
            }
            copy.size = size;
            return copy;
        }
    }
}