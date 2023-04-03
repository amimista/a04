using System.Drawing;
namespace snake
{
    /// <summary>
    /// Representation and Display of the Snake
    /// </summary>
    /// <author>Marcus W + Tyson</author>
    class Snake
    {
        private Queue<Point> snake; // using a queue here since it's conceptually the same as a RingBuffer.

        private Point head;

        public int Vel { get; set; } // used in the Thread.Sleep() in main game class.

        public Direction Direction { get; set; }

        private ConsoleColor headColor;
        private ConsoleColor bodyColor;

        public Snake(int length, Point startingPosition)
        {
            snake = new Queue<Point>(length);
            headColor = ConsoleColor.Red;
            bodyColor = ConsoleColor.Green;
            for (int i = 0; i < length; i++)
            {
                head = new Point(startingPosition.X + i, startingPosition.Y);
                snake.Enqueue(head);

                Board.PrintSquare(head, bodyColor);
            }

            Vel = 100;
            Direction = Direction.Right;
        }

        public Point MoveSnake()
        {
            Point tail = snake.Dequeue();
            Board.PrintSquare(tail, ConsoleColor.DarkBlue); ; // overwriting the old pixel

            Board.PrintSquare(head, bodyColor); // overwriting the position of the head since it's position will become part of the body.

            head = ChangePosition(head); // changing the position of the head based on Direction

            snake.Enqueue(head); // re-adding the head coordinates
            Board.PrintSquare(head, headColor); // displaying where the head is

            return (ChangePosition(head)); // checking the next position of the head. Used in collision handling.
        }

        public Point ChangePosition(Point currentPos)
        {
            switch (Direction)
            {
                case Direction.Right: currentPos.X += 2; break; // is 2 since the "  " is 2 char. long.
                case Direction.Left: currentPos.X -= 2; break; // is 2 since the "  " is 2 char. long.
                case Direction.Up: currentPos.Y -= 1; break;
                case Direction.Down: currentPos.Y += 1; break;
            }
            return currentPos;
        }

        /// <summary>
        /// gets the location of the snake
        /// </summary>
        public IEnumerable<Point> GetLocation()
        {
            return snake.AsEnumerable();
        }
    }
}
