using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueApp
{
    public interface IQueue
    {
        void Enqueue(Object element);
        Object Element();       
        Object Dequeue();
        int Size();
        bool IsEmpty();
        void Clear();
        /*
        IQueue MakeCopy();
        IQueue Filter(Predicate<Object> predicate);
        IQueue Map(Func<Object, Object> func);
        */
    }
}
