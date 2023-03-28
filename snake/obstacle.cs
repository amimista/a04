namespace snake
{
    /// <summary>
    /// Representation of multiple <see cref="Entity"/> that make an obstacle in the game. Used in tandem with <see cref="Snake"/>.
    /// </summary>
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
            Obstacle obstacle3 = new Obstacle(20, 20, 7, ConsoleColor.Blue);
            obstacleList.Add(obstacle3);
        }

        /// <summary>
        /// Displays the representation of multiple entitys as a single shape in the console.
        /// </summary>
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
