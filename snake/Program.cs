// See https://aka.ms/new-console-template for more information
using snake;
Console.SetCursorPosition(50, 5);
Console.WriteLine("Mr Snake");


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
        Console.Clear();
        break;
    }
}

//int top = 10;
//int left = 20;
//int right = 170;
//int bottom = 40;

bool running = true;

Obstacle obstacle = new Obstacle(30, 30, 7, ConsoleColor.Cyan);
obstacle.Display();

Obstacle obstacle2 = new Obstacle(80, 30, 3, ConsoleColor.Cyan);
obstacle2.Display();

Snake snake = new Snake(25, 30, 20, ConsoleColor.Red);
snake.Display();

Console.CursorVisible = false;
double tick = 0;

Snake.generateArena();

//Thread.Sleep(10000);


//string current = "";
//bool moved = false;
while (running)
{
    snake.Move("right");
    //if (moved == false)
    //{
    //}
    //if (Console.KeyAvailable)
    //{
    //    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

    //    if (keyInfo.Key == ConsoleKey.D)
    //    {
    //        snake.Move("right");
    //        current = "right";
    //        moved = true;
    //    }
    //    else if (keyInfo.Key == ConsoleKey.W)
    //    {
    //        moved = true;
    //        snake.Move("up");
    //        current = "up";
    //    }
    //    else
    //    {
    //        snake.Move(current);
    //    }
    //}

    if (snake.CheckIsDead(obstacle.ObstacleList)) break;

    snake.Display();
    Thread.Sleep(100);
    tick += .1;
}
Console.ResetColor();
Console.Clear();
//Console.BackgroundColor = ConsoleColor.White;
//Console.SetCursorPosition(20, 20);
Console.WriteLine($"You Died, You lived for {Math.Floor(tick)}s");

//Console.Clear();
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.DarkGray;



