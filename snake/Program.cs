// See https://aka.ms/new-console-template for more information
using snake;
using System.Media;
using System.Threading;

while (true)
{
    Console.SetCursorPosition(50, 5);
    Console.WriteLine("Mr Snake");

    // add music

    int width = Console.LargestWindowWidth;
    int height = Console.LargestWindowHeight;

    // Set the console window size to the size of the screen
    Console.SetWindowSize(width, height);
    Console.SetBufferSize(width, height);


    bool pressedAnyButton = false;
    while (!pressedAnyButton)
    {
        Console.SetCursorPosition(3, 3);
        Console.WriteLine("Instrutions");
        Console.SetCursorPosition(3, 4);
        Console.WriteLine("Use W A S D to move");
        Console.SetCursorPosition(3, 5);
        Console.WriteLine("Press Enter to begin");
        ConsoleKeyInfo Pressed = Console.ReadKey(true);

        if (Pressed.Key == ConsoleKey.Enter)
        {
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("           ");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("                          ");
            Console.SetCursorPosition(3, 5);
            Console.WriteLine("                            ");
            pressedAnyButton = true;
        }
    }

    bool running = true;

    Obstacle obstacle = new Obstacle(30, 30, 7, ConsoleColor.Cyan);
    obstacle.Display();
    Obstacle obstacle2 = new Obstacle(80, 30, 3, ConsoleColor.Cyan);
    obstacle2.Display();

    List<Entity> allObsticles = new List<Entity>();
    foreach (Entity entity in obstacle.ObstacleList)
    {
        allObsticles.Add(entity);
    }
    foreach (Entity entity in obstacle2.ObstacleList)
    {
        allObsticles.Add(entity);
    }


    Snake snake = new Snake(10, 50, 20, allObsticles);
    snake.Display();


    string currentDirection = "right";
    Console.CursorVisible = false;
    double tick = 0;

    Snake.generateArena();


    currentDirection = "right";
    bool moved = false;



    while (running)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            currentDirection = snake.GetDirection(keyInfo, currentDirection);
        }
        snake.Move(currentDirection);
        snake.Display();



        if (snake.CheckIsDead()) break;
        Thread.Sleep(100);  // (100)
        tick += .1;

        if (tick % 1 == 0)
        {

            Obstacle obstacle3 = new Obstacle(80, 30, 3, ConsoleColor.Cyan);
            obstacle3.Display();

        }
    }
    //Make sound
    int frequency = 440; // Frequency in Hertz (A4 note)
    int duration = 100;   // Duration in milliseconds (0.1 second)
    Console.Beep(frequency, duration);

    Console.Clear();
    Console.ResetColor();

    Console.SetCursorPosition(70, 10);

    Console.ForegroundColor = ConsoleColor.DarkGray;
    Console.WriteLine($"You Died, You lived for {tick}");

    Console.WriteLine("");
    Console.WriteLine("");
    Console.WriteLine("");
    Console.SetCursorPosition(65, 15);
    Console.WriteLine($"click enter to play again any other key twice to exit");


    ConsoleKeyInfo PressedEnter = Console.ReadKey(true);
    if (PressedEnter.Key == ConsoleKey.Enter)
    {

        Console.SetCursorPosition(65, 15);
        Console.WriteLine("                                                ");
        pressedAnyButton = true;

    }
    else if (PressedEnter != null)
    {

        Environment.Exit(0);
        Environment.Exit(0);

    }

}


