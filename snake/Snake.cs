using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Snake
    {
        private RingBuffer body;
        private double speed;

        public double Speed { get; set; }
        public Snake(int startingLeft, int startingTop, int length)
        {
            body = new RingBuffer(length); // length of the snake
            Speed = 1.0;
            for (int i = 0; i < body.Capacity; i++)
            {
                body.Add(new Entity(startingLeft + i, startingTop)); // setting the head of the snake, incramenting by i to display the whole thing
            }

            // test 2
        }
    }
}
