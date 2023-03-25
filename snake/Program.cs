// See https://aka.ms/new-console-template for more information
using snake;
using System;
using System.Drawing;
using System.Security.AccessControl;
//Console.BufferWidth = 300;
//Console.WindowWidth = 200;
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

    if(Pressed.Key == ConsoleKey.Enter)
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

int top = 10;
int left = 20;
int right = 170;
int bottom = 40;



bool running = true;

Obstacle obstacle = new Obstacle(30, 30, 7, ConsoleColor.Cyan);

Obstacle obstacle2 = new Obstacle(80, 30, 3, ConsoleColor.Cyan);
obstacle2.Display();
  obstacle.Display();

    Snake snake = new Snake(10, 30, 20, ConsoleColor.Red);
    snake.Display();

    //directionKey.Key = ConsoleKey.D;
    string currentDirection = "right";
    Console.CursorVisible = false;
double tick = 0;

Snake.generateAreana();


string current = "";
bool moved = false;
while (running)
{
    if (moved == false) {
        snake.Move("right");
    } 
    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        if (keyInfo.Key == ConsoleKey.D)
        {
            snake.Move("right");
            current = "right";
            moved = true;
        }
        else if (keyInfo.Key == ConsoleKey.W)
        {
            moved = true;
            snake.Move("up");
            current = "up";
        }
        else
        {
            snake.Move(current);
        }
    }


    



    

  


      if (snake.CheckIsDead(obstacle.ObstacleList)) break;



      snake.Display();
     Thread.Sleep(100);
    tick += .1;
     }

     
    //  Console.ResetColor();
    //  Console.ForegroundColor = ConsoleColor.DarkGray;
      Console.WriteLine($"You Died, You lived for {tick}");




