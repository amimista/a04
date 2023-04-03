using System.Media;

namespace snake
{
    /// <summary>
    /// Main game program with game setup and utilities.
    /// </summary>
    /// <author>Marcus + Tyson</author>
    class Program
    {
        private static Board board;
        private static Timer? timer;
        private static int elapsedTime;
        private static bool running = true;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            // MAIN TITLE
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("""
  __  __         _____             _        
 |  \/  |       / ____|           | |       
 | \  / |_ __  | (___  _ __   __ _| | _____ 
 | |\/| | '__|  \___ \| '_ \ / _` | |/ / _ \
 | |  | | |_    ____) | | | | (_| |   <  __/
 |_|  |_|_(_)  |_____/|_| |_|\__,_|_|\_\___|
                                            
                                            
""");

            board = new Board();

            // INSTRUCTIONS
            Console.SetCursorPosition(5, 8);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press enter to start...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
                // waiting until enter is presed
            }

            Console.SetCursorPosition(5, 8);
            Console.ResetColor();
            Console.WriteLine(new string(' ', "Press enter to start...".Length)); // overwriting the instructions
            
            do // MAIN GAME LOOP
            {
                NewGame();
                Console.SetCursorPosition(5, 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Press enter twice to play again. Press anything else twice to quit.");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);

            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        private static void NewGame()
        {
            board = new Board();
            timer = new Timer(
                callback: TimerCallback,
                state: null,
                dueTime: 0,
                period: 1000);

            running = true;
            elapsedTime = 0;
            Thread inputThread = new Thread(DirectionKeyChangeListener); // separating the game from the inputs
            inputThread.Start();

            // COLLISION CHECK
            while (!board.DetectCollision(board.Snake.MoveSnake()))
            {
                Thread.Sleep(board.Snake.Vel);
            }

            running = false;

            Console.SetCursorPosition(board.Width + 5 - $"You survived {elapsedTime} seconds".Length, 8);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You survived {elapsedTime} seconds");
            timer.Dispose();

            try
            {
                Console.Beep(1234, 100);
            }
            catch (PlatformNotSupportedException) { }
        }

        private static void TimerCallback(Object o)
        {
            elapsedTime++;

            if (elapsedTime % 10 == 0)
            {
                board.GenObstacles(5);
            }
        }

        static void DirectionKeyChangeListener()
        {
            while (running)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.RightArrow || key == ConsoleKey.D)
                {
                    board.Snake.Direction = Direction.Right;
                }
                else if (key == ConsoleKey.LeftArrow || key == ConsoleKey.A)
                {
                    board.Snake.Direction = Direction.Left;
                }
                else if (key == ConsoleKey.UpArrow || key == ConsoleKey.W)
                {
                    board.Snake.Direction = Direction.Up;
                }
                else if (key == ConsoleKey.DownArrow || key == ConsoleKey.S)
                {
                    board.Snake.Direction = Direction.Down;
                }
            }
        }
    }
}