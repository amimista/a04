using System.Text;

namespace snake
{
    /// <summary>
    /// The class RingBuffer represents a circular buffer of fixed capacity
    /// </summary>
    /// <author>
    /// Marcus Walker
    /// Tyson Potter
    /// </author>
    public class RingBuffer
    {
        public Entity[] items;
        public int front;
        public int rear;
        public int size;
        public int capacity;

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
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

    }
}
