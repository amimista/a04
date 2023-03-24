using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    /// <summary>
    /// The class RingBuffer represents a circular buffer of fixed capacity
    /// </summary>
    /// <author>
    /// Marcus Walker
    /// </author>
    public class RingBuffer<T>
    {
        private T[] items;
        private int front;
        private int rear;
        private int size;
        private int capacity;

        public RingBuffer(int capacity)
        {
            items = new T[capacity];
            front = 0;
            rear = 0;
            size = 0;
            this.capacity = capacity;
        }

        public bool IsEmpty // read only prop
        {
            get { return size == 0; }
        }

        public bool IsFull
        {
            get { return size == capacity; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public int Size
        {
            get { return size; }
        }

        public void Add(T element)
        {
            if (size == capacity)
                throw new InvalidOperationException("Can't add to a full buffer.");

            items[rear] = element;
            rear = ++rear % capacity;
            size++;
        }

        public T Remove()
        {
            if (size == 0)
                throw new InvalidOperationException("Can't remove from empty buffer");

            T element = items[front];
            items[front] = default(T);
            front = ++front % capacity;
            size--;
            return element;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < items.Length; i++)
            {
                if (i == front)
                {
                    sb.Append(items[i] + "^, ");
                }
                else if (i == rear)
                {
                    sb.Append(items[i] + "%, ");
                }
                else
                {
                    sb.Append(items[i] + ", ");
                }
            }
            sb.Remove(sb.Length-2,2);
            return sb.ToString();
        }

    }
}
