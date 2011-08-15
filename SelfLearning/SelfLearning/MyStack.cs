using System;
using System.Collections.Generic;
using System.Text;

namespace SelfLearning
{
    public class MyStack<T>
    {
        Stack<T> stack = new Stack<T>();

        //public MyStack

        public T Pop()
        {
            Console.WriteLine("Poped "+stack.Peek().ToString());
            return stack.Pop();
            
        }

        public void Push(T v)
        {
            Console.WriteLine("Pushed " + v.ToString());
            stack.Push(v);

        }

        public T Peek()
        {
            return stack.Peek();
        }

        public int Count
        {
            get
            {
                return stack.Count;
            }
        }
        
    }
}
