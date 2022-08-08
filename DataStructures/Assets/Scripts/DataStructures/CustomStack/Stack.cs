using System;

namespace DataStructures.CustomStack
{
    public class Stack<T>
    {
        T[] values;
        int length;
        
        const int defaultLength = 4;

        public int Length => length;

        public Stack() => values = new T[defaultLength];

        public void Push(T item)
        {
            if (length == values.Length)
            {
                Array.Resize(ref values, length * 2);
            }
            values[length++] = item;
        }

        public T Pop()
        {
            T item = values[--length];
            values[length] = default(T);
            return item;
        }

        public T Peek()
        {
            return values[length-1];
        }

        public bool Contains(T item)
        {
            int current = length;
            while (current-- > 0)
            {
                if (Equals(values[current], item))
                {
                    return true;
                }
            }
            return false;
        }
        
        public void Clear()
        {
            Array.Clear(values, 0, defaultLength);
            length = 0;
        }

        public override string ToString()
        {
            string stackValues = "";
            stackValues += values[0];
            for (int i = 1; i < length; i++)
            {
                stackValues += $", {values[i]}";
            }

            return stackValues;
        }
    }
}