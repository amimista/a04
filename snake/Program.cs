// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// main while loop
int tick = 0;
bool running = true;

Console.WriteLine("Press 'q' to quit the application...");

while (true)
{
    // Read a key from the console without displaying it
    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

    // Check if the pressed key is 'q'
    if (keyInfo.Key == ConsoleKey.Q)
    {
        break; // Exit the loop
    }

    // Perform some action based on the key press
    Console.WriteLine($"You pressed '{keyInfo.KeyChar}'");
}

Console.WriteLine("Application ended.");