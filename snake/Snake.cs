namespace snake
{
    /// <summary>
    /// Representation of a <see cref="RingBuffer"/> of <see cref="Entity"/>. Controlled by user.
    /// </summary>
    public class Snake
    {
        //public List<Entity> listBody;
        public RingBuffer body;
        private Entity head;
        private Entity body1;
        private Entity body2;
        private Entity body3;
        private Entity body4;
        private Entity body5;
        private Entity body6;
        private Entity body7;
        private Entity body8;
        private Entity rear;

        private ConsoleColor color;
        private ConsoleColor Bodycolor = ConsoleColor.Green;
        private List<Entity> obstacleList;

        public Snake(int length, int startingLeft, int startingTop, List<Entity> obstacleList)
        {
            this.obstacleList = obstacleList;
            RingBuffer body = new RingBuffer(10);
            head = new Entity(startingLeft, startingTop);
            body1 = new Entity(startingLeft - (1 * 2), startingTop);
            body2 = new Entity(startingLeft - (2 * 2), startingTop);
            body3 = new Entity(startingLeft - (3 * 2), startingTop);
            body4 = new Entity(startingLeft - (4 * 2), startingTop);
            body5 = new Entity(startingLeft - (5 * 2), startingTop);
            body6 = new Entity(startingLeft - (6 * 2), startingTop);
            body7 = new Entity(startingLeft - (7 * 2), startingTop);
            body8 = new Entity(startingLeft - (8 * 2), startingTop);
            rear = new Entity(startingLeft - (9 * 2), startingTop);
            body.Add(head);
            obstacleList.Add(body1);
            body.Add(body1);
            obstacleList.Add(body2);
            body.Add(body2);
            obstacleList.Add(body3);
            body.Add(body3);
            obstacleList.Add(body4);
            body.Add(body4);
            obstacleList.Add(body5);
            body.Add(body5);
            obstacleList.Add(body6);
            body.Add(body6);
            obstacleList.Add(body7);
            body.Add(body7);
            obstacleList.Add(body8);
            body.Add(body8);
            obstacleList.Add(rear);
            body.Add(rear);

            // MAKE IT SO THIS IS ITERABLE NOT HARD CODED

        }

        /// <summary>
        /// Displays the representation of multiple entitys as a single shape in the console.
        /// </summary>
        public void Display()
        {

            Boolean firstTime = false;

            Console.SetCursorPosition(head.Left, head.Top);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(" ");
            Console.ResetColor();

            Console.SetCursorPosition(body1.Left, body1.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");
            Console.ResetColor();

            Console.SetCursorPosition(body2.Left, body2.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");

            Console.ResetColor();

            Console.SetCursorPosition(body3.Left, body3.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");
            Console.ResetColor();

            Console.SetCursorPosition(body4.Left, body4.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");
            Console.ResetColor();

            Console.SetCursorPosition(body5.Left, body5.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");
            Console.ResetColor();


            Console.SetCursorPosition(body6.Left, body6.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");
            Console.ResetColor();


            Console.SetCursorPosition(body7.Left, body7.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write(" ");
            Console.ResetColor();


            Console.SetCursorPosition(body8.Left, body8.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write(" ");
            Console.ResetColor();

            Console.SetCursorPosition(rear.Left, rear.Top);
            Console.BackgroundColor = Bodycolor;
            Console.Write("  ");
            Console.ResetColor();


        }

        public void Move(String direction)
        {
            if (direction == "right")
            {
                Console.SetCursorPosition(rear.Left, rear.Top);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("  ");
                Console.BackgroundColor = ConsoleColor.Green;
                rear.Left = body8.Left;
                rear.Top = body8.Top;

                body8.Left = body7.Left;
                body8.Top = body7.Top;

                body7.Left = body6.Left;
                body7.Top = body6.Top;

                body6.Left = body5.Left;
                body6.Top = body5.Top;

                body5.Left = body4.Left;
                body5.Top = body4.Top;

                body4.Left = body3.Left;
                body4.Top = body3.Top;

                body3.Left = body2.Left;
                body3.Top = body2.Top;

                body2.Left = body1.Left;
                body2.Top = body1.Top;


                body1.Left = head.Left;
                body1.Top = head.Top;

                Console.BackgroundColor = ConsoleColor.Red;
                head.Left = head.Left + 2;
                Console.SetCursorPosition(head.Left, head.Top);
                Console.Write("  ");
            }
            else if (direction == "up")
            {
                Console.SetCursorPosition(rear.Left, rear.Top);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("  ");
                Console.BackgroundColor = ConsoleColor.Green;
                rear.Left = body8.Left;
                rear.Top = body8.Top;

                body8.Left = body7.Left;
                body8.Top = body7.Top;

                body7.Left = body6.Left;
                body7.Top = body6.Top;

                body6.Left = body5.Left;
                body6.Top = body5.Top;

                body5.Left = body4.Left;
                body5.Top = body4.Top;

                body4.Left = body3.Left;
                body4.Top = body3.Top;

                body3.Left = body2.Left;
                body3.Top = body2.Top;

                body2.Left = body1.Left;
                body2.Top = body1.Top;


                body1.Left = head.Left;
                body1.Top = head.Top;

                Console.BackgroundColor = ConsoleColor.Red;
                head.Top = head.Top - 1;
                Console.SetCursorPosition(head.Left, head.Top);
                Console.Write("  ");
            }
            else if (direction == "down")
            {
                Console.SetCursorPosition(rear.Left, rear.Top);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("  ");
                Console.BackgroundColor = ConsoleColor.Green;
                rear.Left = body8.Left;
                rear.Top = body8.Top;

                body8.Left = body7.Left;
                body8.Top = body7.Top;

                body7.Left = body6.Left;
                body7.Top = body6.Top;

                body6.Left = body5.Left;
                body6.Top = body5.Top;

                body5.Left = body4.Left;
                body5.Top = body4.Top;

                body4.Left = body3.Left;
                body4.Top = body3.Top;

                body3.Left = body2.Left;
                body3.Top = body2.Top;

                body2.Left = body1.Left;
                body2.Top = body1.Top;


                body1.Left = head.Left;
                body1.Top = head.Top;

                Console.BackgroundColor = ConsoleColor.Red;
                head.Top = head.Top +1;
                Console.SetCursorPosition(head.Left, head.Top);
                Console.Write("  ");
            }
            else if (direction == "left")
            {
                Console.SetCursorPosition(rear.Left, rear.Top);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("  ");
                Console.BackgroundColor = ConsoleColor.Green;
                rear.Left = body8.Left;
                rear.Top = body8.Top;

                body8.Left = body7.Left;
                body8.Top = body7.Top;

                body7.Left = body6.Left;
                body7.Top = body6.Top;

                body6.Left = body5.Left;
                body6.Top = body5.Top;

                body5.Left = body4.Left;
                body5.Top = body4.Top;

                body4.Left = body3.Left;
                body4.Top = body3.Top;

                body3.Left = body2.Left;
                body3.Top = body2.Top;

                body2.Left = body1.Left;
                body2.Top = body1.Top;


                body1.Left = head.Left;
                body1.Top = head.Top;

                Console.BackgroundColor = ConsoleColor.Red;
                head.Left = head.Left + -2;
                Console.SetCursorPosition(head.Left, head.Top);
                Console.Write("  ");
            }
        }


        public bool CheckIsDead()
        {
            bool result = false;
            if ((head.Top < 10 || head.Top >= 40 - 1) || (head.Left < 20 || head.Left >= 170 - 3))
            {
                result = true;
            }
            else
            {
                foreach (Entity e in obstacleList)
                {
                    if (head.Top == e.Top && head.Left == e.Left)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }


        public static void generateArena()
        {

            //Creates areana
            int j = 0;
            for (int i = 0; i < 150; i++)
            {
                Console.SetCursorPosition(20 + j, 10);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ");
                j++;
            }
            // finish the top line
            int l = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.SetCursorPosition(20 + j, 10 + l);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ");
                l++;
            }
            // finish the right line
            j = 0;
            for (int i = 0; i < 29; i++)
            {
                Console.SetCursorPosition(20, 10 + j);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ");
                j++;
            }
            // finish left
            l = 0;
            for (int i = 0; i < 151; i++)
            {
                Console.SetCursorPosition(20 + l, 10 + j);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  ");
                l++;
            }
            // finish bottom
        }

        public string GetDirection(ConsoleKeyInfo keyInfo, string currentDirection)
        {
            if (keyInfo.Key == ConsoleKey.D || keyInfo.Key == ConsoleKey.RightArrow)
            {
                return "right";

            }
            else if (keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow)
            {
                return "up";
            }
            else if (keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.DownArrow)
            {
                return "down";
            }
            else if (keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.LeftArrow)
            {
                return "left";
            }
            else
            {
                return currentDirection;
            }


        }
    }
}
