using System.Drawing;

namespace snake
{
    /// <summary>
    /// Representation and Display of obstacles in the game
    /// </summary>
    /// <author>Marcus W + Tyson</author>
    class Obstacle
    {
        private static List<Point> obsPositions = new List<Point>();

        public List<Point> Positions { get; }

        private static Random rand = new Random();

        /// <summary>
        /// Creates the data behind an obstacle.
        /// </summary>
        /// <param name="w">Width of the play area</param>
        /// <param name="h">Height of the play area</param>
        public Obstacle(int w, int h)
        {
            bool isCollide;
            Point point;
            do
            {
                isCollide = false;
                //                              leftMargin        topMargin
                point = new Point(rand.Next(w - 4), rand.Next(h - 9));
                foreach (Point pos in obsPositions)
                {
                    if (pos.X <= point.X && pos.X >= point.X - 6 &&
                        pos.Y <= point.Y && pos.Y >= point.Y - 3) // making sure obstacles don't come within a certain distance of each other.
                    {
                        isCollide |= true; // logical or operator. Saw this with intellicode, evaluates to `isCollide = isCollide || true;`. So it basically does isCollide = true; none the less.
                    }
                }
            } while (isCollide);

            obsPositions.Add(point);

            Positions = new List<Point>();

            int obsType = rand.Next(4);

            if (obsType == 0)
            {
                createShapeT(point);
            }
            else if (obsType == 1)
            {
                createShapeSkew(point);
            }
            else if (obsType == 2)
            {
                createShapeBlock(point);
            }
            else
            {
                createShapeL(point);
            }

            foreach (Point pos in Positions)
            {
                Board.PrintSquare(pos, ConsoleColor.Cyan);
            }
        }

        public void destroyObstacle()
        {
            foreach (Point pos in Positions)
            {
                obsPositions.Remove(pos); // removing from the list
                Board.PrintSquare(pos, ConsoleColor.DarkBlue); // overwriting the console "pixel"
            }
        }

        private void createShapeT(Point p)
        {
            Positions.Add(new Point(p.X, p.Y + 1));
            Positions.Add(new Point(p.X + 2, p.Y + 1));
            Positions.Add(new Point(p.X, p.Y + 2));
        }

        private void createShapeSkew(Point p)
        {
            Positions.Add(new Point(p.X + 2, p.Y));
            Positions.Add(new Point(p.X + 2, p.Y + 1));
            Positions.Add(new Point(p.X + 4, p.Y + 1));
        }

        private void createShapeBlock(Point p)
        {
            Positions.Add(new Point(p.X + 2, p.Y));
            Positions.Add(new Point(p.X + 2, p.Y + 1));
            Positions.Add(new Point(p.X, p.Y + 1));
        }

        private void createShapeL(Point p)
        {
            Positions.Add(new Point(p.X, p.Y + 1));
            Positions.Add(new Point(p.X + 2, p.Y + 2));
            Positions.Add(new Point(p.X, p.Y + 2));
        }
    }
}
