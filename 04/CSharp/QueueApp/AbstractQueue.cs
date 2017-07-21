using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QueueApp
{
    public abstract class AbstractQueue : IQueue
    {
        abstract public void Enqueue(Object element);

        abstract public Object Element();

        abstract public Object Dequeue();

        abstract public void Clear();

        abstract public int Size();

        abstract public bool IsEmpty();
        
        /*
        abstract public IQueue MakeCopy();
        
        public IQueue Filter(Predicate<Object> predicate)
        {
            IQueue ret = MakeCopy();
            int s = ret.Size();

            for (int i = 0; i < s; i++)
            {
                Object elem = ret.Dequeue();
                //if (predicate.target(elem))
                {
                    ret.Enqueue(elem);
                }
            }

            return ret;
        }

        public IQueue Map(Func<Object, Object> func)
        {
            IQueue ret = MakeCopy();
            int s = ret.Size();
            for (int i = 0; i < s; i++)
            {
                ret.Enqueue(ret.Dequeue());
            }

            return ret;
        }
        */
    }
}
