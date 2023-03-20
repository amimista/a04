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
    public class RingBuffer
    {
        private Entity[] items;
        private int front;
        private int rear;
        private int size;
        private int capacity;

        public RingBuffer(int capacity)
        {
            items = new Entity[capacity];
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

        public void Add(Entity element)
        {
            if (size == capacity)
                throw new InvalidOperationException("Can't add to a full buffer.");

            items[rear] = element;
            rear = ++rear % capacity;
            size++;
        }

        public Entity Remove()
        {
            if (size == 0)
                throw new InvalidOperationException("Can't remove from empty buffer");

            Entity element = items[front];
            items[front] = null;
            front = ++front % capacity;
            size--;
            return element;
        }

    }
}
