using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueApp
{
    public class ListNode
    {
        public Object value;
        public ListNode prev;
        public ListNode next;
        public ListNode(Object value, ListNode prev, ListNode next)
        {
            if (value != null)
            {
                this.value = value;
                this.prev = prev;
                this.next = next;
            }
            else
                throw new InvalidOperationException("Value is empty!");  
        }
    }
}
