// See https://aka.ms/new-console-template for more information
using snake;
bool running = true;

Obstacle obstacle = new Obstacle(10, 4, 3, ConsoleColor.Cyan);
obstacle.Display();

Snake snake = new Snake(5, 8, 2, ConsoleColor.Green);
snake.Display();


while(running)
{
    if (snake.CheckIsDead(obstacle.ObstacleList)) break;

    snake.Move(Direction.Right);

    snake.Display();
    Thread.Sleep(100);
}

Console.SetCursorPosition(0, Console.WindowHeight - 5);
Console.ResetColor();
Console.ForegroundColor = ConsoleColor.DarkGray;
Console.WriteLine("Application ended.");