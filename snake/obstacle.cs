using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public class Obstacle
    {
        private List<Entity> obstacleList;

        private ConsoleColor color;

        public List<Entity> ObstacleList { get { return obstacleList; } set { obstacleList = value; } }

        public Obstacle(int left, int top, int size, ConsoleColor color)
        {
            this.color = color;
            obstacleList = new List<Entity>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    obstacleList.Add(new Entity(left + (i * 2), top + j));
                }
            }
        }

        public void Display()
        {
            foreach (Entity e in obstacleList)
            {
                Console.SetCursorPosition(e.Left, e.Top);
                Console.BackgroundColor = color;
                Console.Write("  ");
                Console.ResetColor();
            }

        }

    }
}
