using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    internal class Snake
    {
        private RingBuffer<Entity> body;
        private Entity head;
        private bool isDead;
        private ConsoleColor color;

        public bool IsDead { get; set; }

        public Snake(int length, int startingLeft, int startingTop, ConsoleColor color)
        {
            this.color = color;
            head = new Entity(startingLeft, startingTop);
        }

        public void Display()
        {
            Console.SetCursorPosition(head.Left, head.Top);
            Console.BackgroundColor = color;
            Console.Write("  ");
            Console.ResetColor();
        }

        public void Move(Direction direction)
        {
            if (direction == Direction.Right)
            {
                head.Left+=2;
                if(head.Left > Console.WindowWidth)
                {
                    IsDead = true;
                }
            }
            else if (direction == Direction.Left)
            {
                head.Left -= 2;
                if (head.Left < 0)
                {
                    IsDead = true;
                }
            }
            else if (direction == Direction.Up)
            {
                head.Top--;
                if (head.Top < 0)
                {
                    IsDead = true;
                }
            }
            else
            {
                head.Top++;
                if (head.Top > Console.WindowHeight)
                {
                    IsDead = true;
                }
            }
        }

        public bool CheckIsDead(List<Entity> obstacleList)
        {
            bool result = false ;
            if ((head.Top < 0 || head.Top >= Console.WindowHeight) || (head.Left < 0 || head.Left >= Console.WindowWidth - 1))
            {
                result = true;
            }
            else
            {
                foreach (Entity e in obstacleList)
                {
                    if (head.Top == e.Top || head.Left == e.Left)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

    }
}
