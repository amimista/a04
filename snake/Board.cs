using System.Drawing;

namespace snake
{
    /// <summary>
    /// Representation and Display of the play-area. Also a massive part in setup of the overall game.
    /// </summary>
    /// <author>Marcus W</author>
    internal class Board
    {
        public Snake Snake { get; set; }

        private Obstacle[] obstacles;

        public int Height { get; }
        public int Width { get; }

        private static int leftMargin = 5;
        private static int topMargin = 9;

        public Board()
        {
            Snake = new Snake(15, new Point(15, 15));
            Height = 20;
            Width = 60;
            for (int i = 0; i < Height; i++) // rows or known visually as Y
            {
                for (int j = 0; j < Width; j++) // columns or known visually as X
                {
                    PrintSquare(new Point(j, i), ConsoleColor.DarkBlue);
                }
            }
            // GENERATE OBSTACLES
            obstacles = new Obstacle[5];
            GenObstacles(obstacles.Length);
        }

        public void GenObstacles(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                if (obstacles[i] != null)
                    obstacles[i].destroyObstacle(); // if there's already an obstacle there, get rid of it
                obstacles[i] = new Obstacle(Width, Height);
            }
        }

        /// <summary>
        /// Checks if snake head (pos) comes in contact with anything other than empty space.
        /// </summary>
        /// <param name="pos"></param>
        /// <returns>true if (pos) is equal to being outside of bounds or hitting an obstacle</returns>
        public bool DetectCollision(Point pos)
        {
            if (pos.X < 0 || pos.Y < 0) return true;
            if (pos.X >= Width || pos.Y >= Height) return true;

            foreach (Obstacle obstacle in obstacles)
            {
                foreach (Point point in obstacle.Positions)
                {
                    if ((pos.X == point.X || pos.X == point.X + 1) && pos.Y == point.Y) return true;
                }
            }

            foreach (Point block in Snake.GetLocation())
                if ((pos.X == block.X) && pos.Y == block.Y) return true;
            
            return false;
        }

        internal static void PrintSquare(Point position, ConsoleColor color)
        {
            Console.SetCursorPosition(position.X + leftMargin, position.Y + topMargin);
            Console.BackgroundColor = color;
            Console.WriteLine("  ");
        }
    }
}
