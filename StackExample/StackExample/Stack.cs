using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExample
{
    public class Stack
    {
        private List<object> elements = new List<object>();

        public bool IsEmpty
        {
            get { return elements.Count == 0; }
        }

        public void Push(object element)
        {
            elements.Insert(0, element);
        }

        public object Pop()
        {
            object top = Top();
            elements.RemoveAt(0);
            return top;
        }

        public object Top()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is Empty");

            return elements[0];
        }
    }
}
